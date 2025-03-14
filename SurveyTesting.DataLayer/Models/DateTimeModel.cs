using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.DataLayer.Models
{
    public class DateTimeModel
    {
        public DateTimeModel()
        {
            CreateDateTime = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Время создания записи.
        /// </summary>
        public DateTimeOffset CreateDateTime { get; set; }

        /// <summary>
        /// Время последнего обновления записи.
        /// </summary>
        [DefaultValue(null)]
        public DateTimeOffset? UpdateDateTime { get; set; }

        /// <summary>
        /// Время удаления записи.
        /// </summary>
        [DefaultValue(null)]
        public DateTimeOffset? DeleteDateTime { get; set; }

        public bool IsDeleted => DeleteDateTime.HasValue;
    }
}
