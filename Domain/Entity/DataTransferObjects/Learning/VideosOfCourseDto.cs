namespace Entity.DataTransferObjects.Learning;

public record VideosOfCourseDto(
    string videoLinc,
    string title,
    string content,
    int courseId,
    int orderNumber,
    List<string> docsUrl);
