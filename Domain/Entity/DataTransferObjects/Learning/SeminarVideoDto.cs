namespace Entity.DataTransferObjects.Learning;

public record SeminarVideoDto(
    string videoLinc,
    string title,
    int authorId,
    int categoryId,
    List<int> hashtagId);