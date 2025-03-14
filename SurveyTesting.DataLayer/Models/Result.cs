using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.DataLayer.Models
{
    [Index(nameof(Id), nameof(InterviewId), nameof(QuestionId))]
    public class Result : DateTimeModel
    {
        /// <summary>
        /// Id результата.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id сессии прохождения, к которой относится результат.
        /// </summary>
        public int InterviewId { get; set; }

        /// <summary>
        /// Id вопроса, на который был дан ответ.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Id выбранного ответа (если ответ был выбран из предложенных вариантов).
        /// </summary>
        public int? AnswerId { get; set; }

        /// <summary>
        /// Текстовое поле для хранения ответа пользователя, если он сам написал ответ.
        /// </summary>
        public string? AnswerText { get; set; }

        public Interview? Interview { get; set; }
        public Question? Question { get; set; }
        public Answer? Answer { get; set; }
    }
}
