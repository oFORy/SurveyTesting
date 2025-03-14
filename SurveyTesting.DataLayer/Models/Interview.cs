using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.DataLayer.Models
{
    [Index(nameof(Id), nameof(UserId), nameof(SurveyId))]
    public class Interview : DateTimeModel
    {
        /// <summary>
        /// Id сессии прохождения.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id пользователя, который проходит анкету.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Id анкеты, которую проходил пользователь.
        /// </summary>
        public int SurveyId { get; set; }

        /// <summary>
        /// Дата и время начала прохождения анкеты
        /// </summary>
        public DateTimeOffset PassingDate { get; set; }

        /// <summary>
        /// Дата и время завершения прохождения анкеты (может быть null, если анкета ещё не завершена
        /// </summary>
        public DateTimeOffset? CompletionDate { get; set; }

        public Survey? Survey { get; set; }
    }
}
