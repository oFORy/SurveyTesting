using Microsoft.EntityFrameworkCore;

namespace SurveyTesting.DataLayer.Models
{
    [Index(nameof(Id), nameof(Name))]
    public class Survey : DateTimeModel
    {
        /// <summary>
        /// Id анкеты (опроса).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название анкеты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание анкеты.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Вопросы в анкете.
        /// </summary>
        public List<Question>? Questions { get; set; }
    }
}
