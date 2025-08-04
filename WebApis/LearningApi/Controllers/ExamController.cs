using Entity.DataTransferObjects.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ExamController(IExamService examService) : ApiControllerBase
{
    [HttpGet]
    public async Task<ResponseModel> GetQuizByCourseId([FromQuery] long courseId)
    {
        return ResponseModel.ResultFromContent(
            await examService.GetQuizByCourseIdAsync(this.UserId,courseId));
    }

    [HttpPost]
    public async Task<ResponseModel> Create([FromBody] CreateExamDto examDto)
    {
        return ResponseModel.ResultFromContent(
            await examService.CreateExamAsync(this.UserId, examDto.quizId));
    }
    [HttpPut]
    public async Task<ResponseModel> Completion([FromBody]ExamDto examDto)
    {
        return ResponseModel.ResultFromContent(
            await examService.CompletionExamAsync(examDto));
    }

    [HttpGet]
    public async Task<ResponseModel> GetExamResultById([FromQuery] long examId)
    {
        return ResponseModel.ResultFromContent(
            await examService.InformationExamAsync(examId));
    }
    [HttpGet]
    public async Task<ResponseModel> GetExamsByUser()
    {
        return ResponseModel.ResultFromContent(
            await examService.GetExamsByUserAsync(this.UserId));
    }
    [HttpPost]
    public async Task<ResponseModel> ReplyQuestion([FromBody]QuestionInExamDto questionInExamDto)
    {
        return ResponseModel.ResultFromContent(
            await examService.ReplyQuestionAsync(questionInExamDto));
    }
}