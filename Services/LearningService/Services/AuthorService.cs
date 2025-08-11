using DatabaseBroker.Repositories;
using Entity.DataTransferObjects.Learning;
using Entity.Exceptions;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore;

namespace LearningService.Services;

public class AuthorService(GenericRepository<Author, long> repository) : IAuthorService
{
    public async Task<Author> CreateAuthorAsync(AuthorDto article/*, long userId*/)
    {
        var result = new Author
        {
            Name = article.name,
            Content = article.content,
            ImageLink = article.imageLink ?? "",
            //UserId = userId
        };
        
        return await repository.AddWithSaveChangesAsync(result);
    }
    public async Task<Author> DeleteAuthorAsync(long articleId/*, long userId*/)
    {
        var articleResult = await repository.GetByIdAsync(articleId)
           ?? throw new NotFoundException("Author not found");
        
        // if(articleResult.UserId != userId)
        //     throw new NotFoundException("Author not found");

        return await repository.RemoveWithSaveChangesAsync(articleId);
    }
    public async Task<AuthorDto> GetAuthorByIdAsync(long id)
    {
        var article = await repository.GetByIdAsync(id)
            ?? throw new NotFoundException("Not Found");

        return new AuthorDto(article.Name,article.Content,article.ImageLink,article.Id,
            article.Courses.Count,
            article.ShortVideos.Count,
            article.SeminarVideos.Count,
            article.Articles.Count);
    }
    public async Task<IList<AuthorDto>> GetAllAuthorAsync()
    {
        var articles = await repository
           .GetAllAsQueryable()
           .Select(author => new AuthorDto(author.Name,author.Content,author.ImageLink,author.Id,0,0,0,0))
           .ToListAsync();

        return articles;
    }
    public async Task<Author> UpdateAuthorAsync(AuthorDto article/*, long userId*/)
    {
        var articleResult = await repository.GetByIdAsync(article.id)
            ?? throw new NotFoundException("Not found");
        
        // if(articleResult.UserId != userId)
        //     throw new NotFoundException("Not found");
        
        articleResult.Name = article.name ?? articleResult.Name;
        articleResult.Content = article.content ?? articleResult.Content;
        articleResult.ImageLink = article.imageLink ?? articleResult.ImageLink;

        return await repository.UpdateWithSaveChangesAsync(articleResult);
    }
}
