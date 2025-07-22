namespace Entity.DataTransferObjects.Learning;

public record ArticleDto(
    string Title,
    string Description,
    string Content,
    int AuthorId,
    int CategoryId,
    List<int> HashtagId,
    string Image);