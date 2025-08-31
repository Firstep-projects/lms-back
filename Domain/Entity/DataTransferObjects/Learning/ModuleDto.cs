namespace Entity.DataTransferObjects.Learning;

public record ModuleDto(
    long Id,
    string Title,
    string Description,
    int OrderNumber,
    int LessonCount,
    TimeSpan Duration,
    long CourseId);