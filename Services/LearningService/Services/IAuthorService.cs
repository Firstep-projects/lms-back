using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;

namespace LearningService.Services;

public interface IAuthorService
{
    Task<Author> CreateAuthorAsync(AuthorDto article, long userId);
    Task<Author> UpdateAuthorAsync(AuthorDto article, long userId);
    Task<Author> DeleteAuthorAsync(long articleId,  long userId);
    Task<AuthorDto> GetAuthorByIdAsync(long id);
    Task<IList<AuthorDto>> GetAllAuthorAsync();
}
