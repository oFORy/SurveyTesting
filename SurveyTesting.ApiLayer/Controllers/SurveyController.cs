using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SurveyTesting.ApiLayer.Params;
using SurveyTesting.DataLayer.Models;
using SurveyTesting.ServiceLayer.Services.Interfaces;

namespace SurveyTesting.ApiLayer.Controllers
{
    [EnableCors("enablecorspolicy")]
    [Route("api/survey")]
    public class SurveyController : Controller
    {
        private readonly IResultService _resultService;
        private readonly IQuestionService _questionService;
        public SurveyController(IResultService resultService, IQuestionService questionService)
        {
            _resultService = resultService;
            _questionService = questionService;
        }

        [HttpGet("questions/{questionId}")]
        public async Task<IActionResult> GetQuestionAsync(int questionId)
        {
            var question = await _questionService.GetQuestionByIdAsync(questionId);
            return new JsonResult(new { Successfully = true, Question = question });
        }


        [HttpPost("interviews/{interviewId}/questions/{questionId}/answers")]
        public async Task<IActionResult> SaveAnswerAsync(int interviewId, int questionId, [FromBody] SaveAnswerParam param)
        {
            var nextQuestionId = await _resultService.SaveResultAsync(interviewId, questionId, param.AnswerId, param.AnswerText);
            return new JsonResult(new { Successfully = true, NextQuestionId = nextQuestionId });
        }
    }
}
