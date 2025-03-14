using SurveyTesting.DataLayer.Functions.Functions;
using SurveyTesting.DataLayer.Models;
using SurveyTesting.ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.ServiceLayer.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionFunc _questionFunc;
        public QuestionService(IQuestionFunc questionFunc)
        {
            _questionFunc = questionFunc;
        }

        /// <inheritdoc/>
        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            return await _questionFunc.GetQuestionByIdAsync(questionId);
        }
    }
}
