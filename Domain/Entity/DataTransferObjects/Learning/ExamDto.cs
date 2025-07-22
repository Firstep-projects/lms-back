using Entity.Enum;

namespace Entity.DataTransferObjects.Learning;

public record ExamDto(
    long id,
    long quizId,
    string title,
    long? createAt,
    long? finishidAt,
    ExamStatus? status,
    int?  remainedHeart,
    List<QuestionInExamDto> questions);