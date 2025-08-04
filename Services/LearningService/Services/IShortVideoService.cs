using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;

namespace LearningService.Services;

public interface IShortVideoService
{
    Task<ShortVideo> CreateShortVideoAsync(ShortVideoDto article);
    Task<ShortVideo> UpdateShortVideoAsync(ShortVideo article);
    Task<ShortVideo> DeleteShortVideoAsync(long articleId);
    Task<IList<ShortVideo>> GetShortVideoByCategoryIdAsync(MetaQueryModel metaQuery, long categoryId);
    Task<IList<ShortVideoForWithDetailsDto>> GetShortVideoWithDetailsAsync(MetaQueryModel metaQuery);
    Task<IList<ShortVideo>> GetShortVideoByAftorIdAsync(MetaQueryModel metaQuery, long aftorId);
    Task<IList<ShortVideo>> GetShortVideoByHashtagIdAsync(MetaQueryModel metaQuery, long hashtagId);
    Task<IList<ShortVideo>> GetAllShortVideoAsync(MetaQueryModel metaQuery);
}
