using Microsoft.EntityFrameworkCore;
using SurveyTesting.DataLayer.Models;

namespace SurveyTesting.DataLayer
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.SetCommandTimeout(300);
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region First Data

            modelBuilder.Entity<Survey>()
                .HasData(new Survey
                {
                    Id = 1,
                    Name = "Пример анкеты",
                    Description = "Описание примера анкеты"
                });

            modelBuilder.Entity<Interview>()
                .HasData(new Interview
                {
                    Id = 1,
                    UserId = 1,
                    SurveyId = 1,
                    PassingDate = DateTime.Now,
                });

            modelBuilder.Entity<Question>()
                .HasData(new[]
                {
                    new Question
                    {
                        Id = 1,
                        Text = "В каком регионе Вы проживаете?",
                        Order = 1,
                        SurveyId = 1
                    },
                    new Question
                    {
                        Id = 2,
                        Text = "Сколько вам лет?",
                        Order = 2,
                        SurveyId = 1
                    },
                    new Question
                    {
                        Id = 3,
                        Text = "Готовы к переезду?",
                        Order = 3,
                        SurveyId = 1
                    }
                });

            modelBuilder.Entity<Answer>()
                .HasData(new[]
                {
                    new Answer { Id = 1, Text = "Москва", Order = 1, QuestionId = 1 },
                    new Answer { Id = 2, Text = "Московская область", Order = 2, QuestionId = 1 },
                    new Answer { Id = 3, Text = "Санкт-Петербург", Order = 3, QuestionId = 1 },
                    new Answer { Id = 4, Text = "Ленинградская область", Order = 4, QuestionId = 1 },
                    new Answer { Id = 5, Text = "Рязанская область", Order = 5, QuestionId = 1 },
                    new Answer { Id = 6, Text = "Владимирская область", Order = 6, QuestionId = 1 },
                    new Answer { Id = 7, Text = "Тульская область", Order = 7, QuestionId = 1 },
                    new Answer { Id = 8, Text = "Другой регион", Order = 8, QuestionId = 1 }
                });

            modelBuilder.Entity<Answer>()
                .HasData(new[]
                {
                    new Answer { Id = 9, Text = "18-30", Order = 1, QuestionId = 2 },
                    new Answer { Id = 10, Text = "30-45", Order = 2, QuestionId = 2 },
                    new Answer { Id = 11, Text = "45-60", Order = 3, QuestionId = 2 },
                    new Answer { Id = 12, Text = "60-70", Order = 4, QuestionId = 2 },
                    new Answer { Id = 13, Text = "Старше 70", Order = 5, QuestionId = 2 }
                });

            modelBuilder.Entity<Answer>()
                .HasData(new[]
                {
                    new Answer { Id = 14, Text = "Да", Order = 1, QuestionId = 3 },
                    new Answer { Id = 15, Text = "Нет", Order = 2, QuestionId = 3 }
                });
            #endregion
        }
    }
}
