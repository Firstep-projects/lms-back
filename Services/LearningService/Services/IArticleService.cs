using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;

namespace LearningService.Services;

public interface IArticleService
{ 
    Task<Article> CreateArticleAsync(ArticleDto article);
    Task<Article> UpdateArticleAsync(Article article);
    Task<Article> DeleteArticleAsync(long articleId);
    Task<Article> GetArticleByIdAsync(long id);
    Task<IList<Article>> GetAllArticleAsync(MetaQueryModel metaQuery);
    Task<IList<Article>> GetAllArticleByHashtagIdAsync(MetaQueryModel metaQuery,long hashtagId);
    Task<IList<Article>> GetAllArticleByAuthorIdAsync(MetaQueryModel metaQuery,long authorId);
    Task<IList<Article>> GetAllArticleByCategoryIdAsync(MetaQueryModel metaQuery,long categoryId);
    Task<IList<ArticleForWithDetailsDto>> GetArticleWithDetailsAsync(MetaQueryModel metaQuery);
}