namespace Entity.DataTransferObjects.Learning;

public record ShortVideoDto(
    string videoLinc,
    string title,
    int authorId,
    int categoryId,
    List<int> hashtagId);