using SurveyTesting.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.DataLayer.Functions.Functions
{
    public interface IQuestionFunc
    {
        /// <summary>
        /// Получить информацию о вопросе и его ответах по id вопроса.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public Task<Question> GetQuestionByIdAsync(int questionId);

        /// <summary>
        /// Получение id следующего вопроса. P.s. Вообще я бы сразу возращал модель следующего вопроса чтобы экономить трафик без повторного обращения, но по заданию надо id.
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public Task<int> GetNextQuestionIdAsync(int questionId);
    }
}
