using Microsoft.EntityFrameworkCore;

namespace SurveyTesting.DataLayer.Models
{
    [Index(nameof(Id), nameof(SurveyId))]
    public class Question : DateTimeModel
    {
        /// <summary>
        /// Id вопроса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст вопроса.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Очередность вопроса в анкете.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Id анкеты в которой есть этот вопрос.
        /// </summary>
        public int SurveyId { get; set; }


        public Survey? Survey { get; set; }

        public List<Answer>? Answers { get; set; }
    }
}
