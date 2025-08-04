using Entity.Models.Learning;

namespace Entity.DataTransferObjects.Learning;

public record AuthorDto(
    string name,
    string? content,
    string? imageLink = "",
    long id = 0,
    int? courseCount = 0,
    int? shortVideoCount = 0,
    int? seminarVideoCount = 0,
    int? articleCount = 0);