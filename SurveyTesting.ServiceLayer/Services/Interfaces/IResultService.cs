using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.ServiceLayer.Services.Interfaces
{
    public interface IResultService
    {
        /// <summary>
        /// Сохранение результатов и получение id следующего вопроса.
        /// </summary>
        /// <param name="interviewId"></param>
        /// <param name="questionId"></param>
        /// <param name="answerId"></param>
        /// <param name="answerText"></param>
        /// <returns></returns>
        public Task<int> SaveResultAsync(int interviewId, int questionId, int answerId, string? answerText);
    }
}
