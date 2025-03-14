using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SurveyTesting.DataLayer;
using SurveyTesting.DataLayer.Functions.Functions;
using SurveyTesting.DataLayer.Functions.Interfaces;
using SurveyTesting.ServiceLayer.Services.Interfaces;
using SurveyTesting.ServiceLayer.Services.Services;

namespace SurveyTesting.ApiLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        readonly string MySpecificCorsOrigins = "enablecorspolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string[] origins = Configuration.GetSection("CorsOrigins:Urls").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MySpecificCorsOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(origins);
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                      builder.AllowCredentials();
                                  });
            });

            services.AddControllers(config =>
            {
            }).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "For testing. Kopyl Sergey",
                    Description = "ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Kopyl Sergey, my telegram",
                        Email = string.Empty,
                        Url = new Uri("https://t.me/ofory_p"),
                    },
                });
            });

            var connectionStringDB = Environment.GetEnvironmentVariable("DB_CS");

            var baseDbOptions = new DbContextOptionsBuilder<DataBaseContext>()
                .UseNpgsql(connectionStringDB, options => options.EnableRetryOnFailure())
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;

            string connectionStringDBContext = Configuration.GetSection("DB_CS").Value;

            services.AddDbContext<DataBaseContext>(options =>
                options.UseNpgsql(connectionStringDBContext, o => o.EnableRetryOnFailure())
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            /// DataFunctions
            services.AddScoped<IQuestionFunc>(provider => new QuestionFunc(baseDbOptions));
            services.AddScoped<IResultFunc>(provider => new ResultFunc(baseDbOptions));

            /// Services
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IResultService, ResultService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
                c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "For testing. Kopyl Sergey");
                c.RoutePrefix = "api/swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MySpecificCorsOrigins);
            });
        }
    }
}
