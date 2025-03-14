namespace SurveyTesting.ApiLayer.Params
{
    public class SaveAnswerParam
    {
        /// <summary>
        /// Id выбранного ответа (если ответ был выбран из предложенных вариантов).
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Текстовое поле для хранения ответа пользователя, если он сам написал ответ.
        /// </summary>
        public string? AnswerText { get; set; }
    }
}
