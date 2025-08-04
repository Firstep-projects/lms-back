using DatabaseBroker.Repositories;
using Entity.DataTransferObjects.Learning;
using Entity.Exceptions;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore;

namespace LearningService.Services;

public class VideoOfCourseService(GenericRepository<VideoOfCourse, long>  videoOfCourseRepository) : IVideoOfCourseService
{
    public async Task<VideoOfCourse> CreateVideoOfCourseAsync(VideosOfCourseDto videoOfCourse)
    {
        var  VideoOfCourse = new VideoOfCourse()
        {
            Link =  videoOfCourse.videoLinc
        };

        return await videoOfCourseRepository.AddWithSaveChangesAsync(VideoOfCourse);
    }
    public async Task<VideoOfCourse> DeleteVideoOfCourseAsync(long id)
    {
        var articleResult = await videoOfCourseRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Logotype not found");

        return await videoOfCourseRepository.RemoveWithSaveChangesAsync(id);
    }
    public async Task<IList<VideoOfCourse>> GetAllVideoOfCourseAsync(MetaQueryModel metaQuery)
    {
        var articles = await videoOfCourseRepository
           .GetAllAsQueryable()
           .Skip(metaQuery.Skip)
           .Take(metaQuery.Take)
           .Select(voc => new VideoOfCourse()
           {
               Id = voc.Id,
           })
           .ToListAsync();

        return articles;
    }
    public async Task<IList<VideoOfCourse>> GetVideoOfCourseByCourseIdAsync(MetaQueryModel metaQuery, long courseId)
    {
        var result = await videoOfCourseRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(voc => new VideoOfCourse()
            {
                Id = voc.Id,
            })
            .ToListAsync();

        return result;
    }

    public async Task<VideoOfCourse> GetVideoOfCourseByIdAsync(long id)
    {
        var result = await videoOfCourseRepository
            .GetByIdAsync(id);

        return result;
    }
    public async Task<VideoOfCourse> UpdateVideoOfCourseAsync(VideoOfCourse videoOfCourse)
    {
        var result = await videoOfCourseRepository.GetByIdAsync(videoOfCourse.Id)
            ?? throw new NotFoundException("Logotype not found");
        

        return await videoOfCourseRepository.UpdateWithSaveChangesAsync(result);
    }
}
