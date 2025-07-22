using Entity.Models.Learning;

namespace Entity.DataTransferObjects.Learning;

public record QuestionDto(
    long? id,
    long quizId,
    int orderNumber,
    string? content,
    string? imageLink,
    string? docLink,
    decimal? ball,
    List<SimpleQuestionOption> options);