using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;

namespace LearningService.Services;

public interface ISeminarVideoService
{
    Task<SeminarVideo> CreateSeminarVideoAsync(SeminarVideoDto seminarVideo);
    Task<Category> CreateSeminarVideoCategoryAsync(CategoryDto seminarVideoCategory);
    Task<IList<SeminarVideo>> GetSeminarVideoByCategoryIdAsync( MetaQueryModel metaQuery,long categoryId);
    Task<IList<SeminarVideoForWhithDetaileDto>> GetSeminarVideoWithDetailsAsync(MetaQueryModel metaQuery);
    Task<IList<SeminarVideo>> GetAllSeminarVideoAsync( MetaQueryModel metaQuery);
    Task<IList<SeminarVideo>> GetAllSeminarVideoByHashtagIdAsync( MetaQueryModel metaQuery,long hashtagId);
    Task<IList<SeminarVideo>> GetAllSeminarVideoByAuthorIdAsync( MetaQueryModel metaQuery, long authorId);
    Task<IList<Category>> GetAllSeminarVideoCategoryAsync(MetaQueryModel metaQuery);
    Task<Category> GetCategoryById(long id);
    Task<SeminarVideo> UpdateSeminarVideoAsync(SeminarVideo seminarVideo);
    Task<Category> UpdateSeminarVideoCategoryAsync(Category seminarVideoCategory);
    Task<SeminarVideo> DeleteSeminarVideoAsync(long seminarVideoId);
    Task<Category>  DeleteSeminarVideoCategoryAsync(long categoryId);
}