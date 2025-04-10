using SurveyTesting.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTesting.DataLayer.Functions.Functions
{
    public interface IResultFunc
    {
        /// <summary>
        /// Сохранение результата в базе данных.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public Task SaveResultAsync(Result result);
    }
}
