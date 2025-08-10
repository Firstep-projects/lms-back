using DatabaseBroker.Repositories;
using Entity.DataTransferObjects.Learning;
using Entity.Exceptions;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore;

namespace LearningService.Services;

public class ArticleService(GenericRepository<Article, long>  articleRepository) : IArticleService
{
    public async Task<Article> CreateArticleAsync(ArticleDto article)
    {
        var newArticle = new Article()
        {
            Title = article.Title,
            Description = article.Description,
            Content = article.Content,
            Image = article.Image,
            CategoryId = article.CategoryId,
        };

        return await articleRepository.AddWithSaveChangesAsync(newArticle);
    }

    public async Task<Article> DeleteArticleAsync(long articleId)
    {
        var articleResult = await articleRepository.GetByIdAsync(articleId)
            ?? throw new NotFoundException("Logotype not found");

        return await articleRepository.RemoveWithSaveChangesAsync(articleId);
    }

    public async Task<IList<Article>> GetAllArticleAsync(MetaQueryModel metaQuery)
    {
        var articles = await articleRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(a => new Article()
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Image = a.Image,
                AuthorId = a.AuthorId,
                Author = new Author(){Id = a.Author.Id,Name = a.Author.Name,ImageLink = a.Author.ImageLink,Content = a.Author.Content},
                CategoryId = a.CategoryId,
                Category = new Category(){Id = a.Category.Id,Description = a.Category.Description,Title = a.Category.Title,ImageLink = a.Category.ImageLink},
            })
            .ToListAsync();

        return articles;
    }

    public async Task<IList<Article>> GetAllArticleByCategoryIdAsync(MetaQueryModel metaQuery, long categoryId)
    {
        var articles = await articleRepository
            .GetAllAsQueryable()
            .Where(a => a.CategoryId == categoryId)
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(a => new Article()
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Image = a.Image,
                AuthorId = a.AuthorId,
                Author = new Author(){Id = a.Author.Id,Name = a.Author.Name,ImageLink = a.Author.ImageLink,Content = a.Author.Content},
                CategoryId = a.CategoryId,
                Category = new Category(){Id = a.Category.Id,Description = a.Category.Description,Title = a.Category.Title,ImageLink = a.Category.ImageLink},
            })
            .ToListAsync();

        return articles;
    }

    public async Task<IList<ArticleForWithDetailsDto>> GetArticleWithDetailsAsync(MetaQueryModel metaQuery)
    {
        var articles = articleRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(a => new Article()
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Image = a.Image,
                AuthorId = a.AuthorId,
                Author = new Author(){Id = a.Author.Id,Name = a.Author.Name,ImageLink = a.Author.ImageLink,Content = a.Author.Content},
                CategoryId = a.CategoryId,
                Category = new Category(){Id = a.Category.Id,Description = a.Category.Description,Title = a.Category.Title,ImageLink = a.Category.ImageLink},
            })
            .ToList();

        var result = articles.Select(x => new ArticleForWithDetailsDto()
        {
            id = x.Id,
            title = x.Title,
            content = x.Content,
            image = x.Image,
            author = x.Author,
            category = x.Category
        }).ToList();
        
        return result;
    }
    
    public async Task<Article> GetArticleByIdAsync(long id)
    {
        var article = await articleRepository.GetByIdAsync(id);

        return article;
    }

    public async Task<Article> UpdateArticleAsync(Article article)
    {
        var articleResult = await articleRepository.GetByIdAsync(article.Id)
            ?? throw new NotFoundException("Not found");

        articleResult.Title = article.Title ?? articleResult.Title;
        articleResult.Content = article.Content ?? articleResult.Content;
        articleResult.Description = article.Description ?? articleResult.Description;
        articleResult.Image = article.Image ?? articleResult.Image;
        articleResult.CategoryId = article.CategoryId is not 0 ? article.CategoryId : articleResult.CategoryId;
        articleResult.AuthorId = article.AuthorId is not 0 ? article.AuthorId : articleResult.AuthorId;

        return await articleRepository.UpdateWithSaveChangesAsync(articleResult);
    }

    public async Task<IList<Article>> GetAllArticleByHashtagIdAsync(MetaQueryModel metaQuery, long hashtagId)
    {
        var newArticle = await articleRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(a => new Article()
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Image = a.Image,
                AuthorId = a.AuthorId,
                Author = new Author() { Id = a.Author.Id, Name = a.Author.Name, ImageLink = a.Author.ImageLink },
                CategoryId = a.CategoryId,
                Category = new Category()
                    { Id = a.Category.Id, Title = a.Category.Title, ImageLink = a.Category.ImageLink },
            }).ToListAsync();

        return newArticle;
    }

    public async Task<IList<Article>> GetAllArticleByAuthorIdAsync(MetaQueryModel metaQuery, long authorId)
    {
        var newArticle = await articleRepository
            .GetAllAsQueryable()
            .Where(x => x.AuthorId == authorId)
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(a => new Article()
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Image = a.Image,
                AuthorId = a.AuthorId,
                Author = new Author() { Id = a.Author.Id, Name = a.Author.Name, ImageLink = a.Author.ImageLink },
                CategoryId = a.CategoryId,
                Category = new Category() { Id = a.Category.Id, Title = a.Category.Title, ImageLink = a.Category.ImageLink },
            })
            .ToListAsync();
        
        return newArticle;
    }
}
