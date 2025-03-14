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
    public class ResultService : IResultService
    {
        private readonly IQuestionFunc _questionFunc;
        private readonly IResultFunc _resultFunc;
        public ResultService(IQuestionFunc questionFunc, IResultFunc resultFunc)
        {
            _questionFunc = questionFunc;
            _resultFunc = resultFunc;
        }

        /// <inheritdoc/>
        public async Task<int> SaveResultAsync(int interviewId, int questionId, int answerId, string? answerText)
        {
            Result result = new Result()
            {
                InterviewId = interviewId,
                QuestionId = questionId,
                AnswerId = answerId,
                AnswerText = answerText
            };
            await _resultFunc.SaveResultAsync(result);
            var nextQuestionId = await _questionFunc.GetNextQuestionIdAsync(questionId);
            return nextQuestionId;
        }
    }
}
