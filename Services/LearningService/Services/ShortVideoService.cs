using DatabaseBroker.Repositories;
using Entity.DataTransferObjects.Learning;
using Entity.Exceptions;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore;

namespace LearningService.Services;

public class ShortVideoService(
    GenericRepository<ShortVideo, long> shortVideoRepository)
    : IShortVideoService
{
    public async Task<ShortVideo> CreateShortVideoAsync(ShortVideoDto article)
    {
        var result = new ShortVideo()
        {
            Title = article.title,
            VideoLinc = article.videoLinc,
            AuthorId = article.authorId,
            CategoryId = article.categoryId,
        };

        return await shortVideoRepository.AddWithSaveChangesAsync(result);
    }

    public async Task<ShortVideo> DeleteShortVideoAsync(long articleId)
    {
        var  articleResult = await shortVideoRepository.GetByIdAsync(articleId)
           ?? throw new NotFoundException("Logotype not found");

        return await shortVideoRepository.RemoveWithSaveChangesAsync(articleId);
    }

    public async Task<IList<ShortVideo>> GetAllShortVideoAsync(MetaQueryModel metaQuery)
    {
        var shortVideos = await shortVideoRepository
          .GetAllAsQueryable()
          .Skip(metaQuery.Skip)
          .Take(metaQuery.Take)
          .Select(sh => new ShortVideo()
          {
              Id = sh.Id,
              VideoLinc = sh.VideoLinc,
              Title = sh.Title,
              AuthorId = sh.AuthorId,
              Author = new Author(){Id = sh.Author.Id,Name = sh.Author.Name,Content = sh.Author.Content,ImageLink = sh.Author.ImageLink},
              CategoryId = sh.CategoryId,
              Category = new Category(){Id = sh.Category.Id,Title = sh.Category.Title,Description = sh.Category.Description,ImageLink = sh.Category.ImageLink},
          })
          .ToListAsync();

        return shortVideos;
    }

    public async Task<IList<ShortVideo>> GetShortVideoByAftorIdAsync(MetaQueryModel metaQuery, long aftorId)
    {
        var articles =  await shortVideoRepository
          .GetAllAsQueryable()
          .Where(x => x.AuthorId == aftorId)
          .Skip(metaQuery.Skip)
          .Take(metaQuery.Take)
          .Select(sh => new ShortVideo()
          {
              Id = sh.Id,
              VideoLinc = sh.VideoLinc,
              Title = sh.Title,
              AuthorId = sh.AuthorId,
              Author = new Author(){Id = sh.Author.Id,Name = sh.Author.Name,ImageLink = sh.Author.ImageLink},
              CategoryId = sh.CategoryId,
              Category = new Category(){Id = sh.Category.Id,Title = sh.Category.Title,ImageLink = sh.Category.ImageLink},
          })
          .ToListAsync();

        return articles;
    }

    public async Task<IList<ShortVideo>> GetShortVideoByCategoryIdAsync(MetaQueryModel metaQuery, long categoryId)
    {
        var articles = await shortVideoRepository
          .GetAllAsQueryable()
          .Where(x => x.CategoryId == categoryId)
          .Skip(metaQuery.Skip)
          .Take(metaQuery.Take)
          .Select(sh => new ShortVideo()
          {
              Id = sh.Id,
              VideoLinc = sh.VideoLinc,
              Title = sh.Title,
              AuthorId = sh.AuthorId,
              Author = new Author(){Id = sh.Author.Id,Name = sh.Author.Name,Content = sh.Author.Content,ImageLink = sh.Author.ImageLink},
              CategoryId = sh.CategoryId,
              Category = new Category(){Id = sh.Category.Id,Title = sh.Category.Title,Description = sh.Category.Description,ImageLink = sh.Category.ImageLink},
          })
          .ToListAsync();

        return articles;
    }

    public async Task<IList<ShortVideo>> GetShortVideoByHashtagIdAsync(MetaQueryModel metaQuery, long hashtagId)
    {
        var filteredItems = await shortVideoRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(sh => new ShortVideo()
            {
                Id = sh.Id,
                VideoLinc = sh.VideoLinc,
                Title = sh.Title,
                AuthorId = sh.AuthorId,
                Author = new Author(){Id = sh.Author.Id,Name = sh.Author.Name,ImageLink = sh.Author.ImageLink},
                CategoryId = sh.CategoryId,
                Category = new Category(){Id = sh.Category.Id,Title = sh.Category.Title,ImageLink = sh.Category.ImageLink},
            })
            .ToListAsync();

        return filteredItems;
    }

    public async Task<IList<ShortVideoForWithDetailsDto>> GetShortVideoWithDetailsAsync(MetaQueryModel metaQuery)
    {
        var shortVideos = await shortVideoRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(sh => new ShortVideo()
            {
                Id = sh.Id,
                VideoLinc = sh.VideoLinc,
                Title = sh.Title,
                AuthorId = sh.AuthorId,
                Author = new Author(){Id = sh.Author.Id,Name = sh.Author.Name,Content = sh.Author.Content,ImageLink = sh.Author.ImageLink},
                CategoryId = sh.CategoryId,
                Category = new Category(){Id = sh.Category.Id,Title = sh.Category.Title,Description = sh.Category.Description,ImageLink = sh.Category.ImageLink},
            })
            .ToListAsync();

        var result = shortVideos.Select(x => new ShortVideoForWithDetailsDto
        {
            id = x.Id,
            title = x.Title,
            author = x.Author,
            category = x.Category,
            videoLinc = x.VideoLinc,
        }).ToList();

        return result;
    }

    public async Task<ShortVideo> UpdateShortVideoAsync(ShortVideo article)
    {
        var articleResult = await shortVideoRepository.GetByIdAsync(article.Id)
           ?? throw new NotFoundException("Logotype not found");

        articleResult.Title = article.Title ?? articleResult.Title;
        articleResult.VideoLinc = article.VideoLinc ?? articleResult.VideoLinc;
        articleResult.CategoryId = article.CategoryId != 0 ? article.CategoryId : articleResult.CategoryId;
        articleResult.AuthorId = article.AuthorId != 0 ? article.AuthorId : articleResult.AuthorId;

        return await shortVideoRepository.UpdateWithSaveChangesAsync(articleResult);
    }
}
