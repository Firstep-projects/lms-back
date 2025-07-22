using Entity.Enum;
using Entity.Models.Learning;

namespace Entity.DataTransferObjects.Learning;

public record QuestionInExamDto(
    long id,
    long examId,
    QuestionTypes type,
    int orderNumber,
    string? content,
    string? imageLink,
    string? docLink,
    string? writtenAnswer,
    bool? checkeding,
    decimal? AccumulatedBall,
    Guid? selected,
    List<SimpleQuestionOption>? options);