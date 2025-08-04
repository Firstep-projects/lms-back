using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class QuizController(IQuizService quizService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateQuiz(QuizDto quizDto)
    {
        return ResponseModel
            .ResultFromContent(await quizService.CreateQuizAsync(quizDto));
    }
    
    [HttpPost]
    public async Task<ResponseModel> CreateQuestion(QuestionDto questionDto)
    {
        return ResponseModel
            .ResultFromContent(await quizService.CreateQuestionAsync(questionDto));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllQuiz([FromQuery]int courseId)
    {
        var res = await quizService.GetQuizIncludeQuestionsByIdAsync(courseId);
        return ResponseModel
            .ResultFromContent(new {quiz = res.Item1,questions = res.Item2});
    }

    [HttpGet]
    public async Task<ResponseModel> GetQuizById(int id)
    {
        return ResponseModel
            .ResultFromContent(await quizService.GetQuizByIdAsync(id));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateQuiz(QuizDto quizDto)
    {
        return ResponseModel
            .ResultFromContent(await quizService.UpdateQuizAsync(quizDto));
    }
    
    [HttpPut]
    public async Task<ResponseModel> UpdateQuestion(QuestionDto questionDto)
    {
        return ResponseModel
            .ResultFromContent(await quizService.UpdateQuestionAsync(questionDto));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteQuiz(int id)
    {
        return ResponseModel
            .ResultFromContent(await quizService.DeleteQuizAsync(id));
    }
    [HttpDelete]
    public async Task<ResponseModel> DeleteQuestion(long id)
    {
        return ResponseModel
            .ResultFromContent(await quizService.DeleteQuestionAsync(id));
    }
}
