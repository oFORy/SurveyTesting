using SurveyTesting.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.ServiceLayer.Services.Interfaces
{
    public interface IQuestionService
    {
        /// <summary>
        /// Получить информацию о вопросе и его ответах по id вопроса.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public Task<Question> GetQuestionByIdAsync(int questionId);
    }
}
