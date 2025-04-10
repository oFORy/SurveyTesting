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
    public class QuestionFunc : IQuestionFunc
    {
        private readonly DbContextOptions<DataBaseContext> _options;
        public QuestionFunc(DbContextOptions<DataBaseContext> options)
        {
            _options = options;
        }

        /// <inheritdoc/>
        public async Task<int> GetNextQuestionIdAsync(int questionId)
        {
            using DataBaseContext db = new DataBaseContext(_options);
            var currentQuestion = await db.Questions
                .Include(q => q.Survey)
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (currentQuestion == null)
            {
                throw new Exception("Вопрос не найден");
            }

            var nextQuestion = await db.Questions
                .Where(q => q.SurveyId == currentQuestion.SurveyId && q.Order > currentQuestion.Order)
                .OrderBy(q => q.Order)
                .FirstOrDefaultAsync();

            return nextQuestion?.Id ?? 0;
        }

        /// <inheritdoc/>
        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            using DataBaseContext db = new DataBaseContext(_options);
            return await db.Questions.AsNoTracking().Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == questionId);
        }
    }
}
