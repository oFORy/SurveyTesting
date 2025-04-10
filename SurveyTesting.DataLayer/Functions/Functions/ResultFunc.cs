using Microsoft.EntityFrameworkCore;
using SurveyTesting.DataLayer.Functions.Functions;
using SurveyTesting.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.DataLayer.Functions.Interfaces
{
    public class ResultFunc : IResultFunc
    {
        private readonly DbContextOptions<DataBaseContext> _options;
        public ResultFunc(DbContextOptions<DataBaseContext> options)
        {
            _options = options;
        }

        /// <inheritdoc/>
        public async Task SaveResultAsync(Result result)
        {
            using DataBaseContext db = new DataBaseContext(_options);
            await db.Results.AddAsync(result);
            await db.SaveChangesAsync();
        }
    }
}
