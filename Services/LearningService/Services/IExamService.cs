using Entity.DataTransferObjects.Learning;

namespace LearningService.Services;

public interface IExamService
{
    Task<ExamDto> CreateExamAsync(long userId, long quizId);
    Task<ExamDto> CompletionExamAsync(ExamDto examDto);
    Task<ExamResultDto> InformationExamAsync(long examId);
    Task<List<ExamForListDto>> GetExamsByUserAsync(long userId);
    Task<QuestionInExamDto> ReplyQuestionAsync(QuestionInExamDto questionInExamDto);
    Task<QuizInfoDto> GetQuizByCourseIdAsync(long userId,long courseId);
}