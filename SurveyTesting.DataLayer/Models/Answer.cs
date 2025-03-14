using Microsoft.EntityFrameworkCore;

namespace SurveyTesting.DataLayer.Models
{
    [Index(nameof(Id), nameof(QuestionId))]
    public class Answer : DateTimeModel
    {
        /// <summary>
        /// Id ответа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст ответа.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Очередность ответа в вопросе.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Id вопроса.
        /// </summary>
        public int QuestionId { get; set; }

        public Question? Question { get; set; }
    }
}
