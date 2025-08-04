using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;

namespace LearningService.Services;

public interface IVideoOfCourseService
{
    Task<VideoOfCourse> CreateVideoOfCourseAsync(VideosOfCourseDto videoOfCourse);
    Task<IList<VideoOfCourse>> GetAllVideoOfCourseAsync(MetaQueryModel metaQuery);
    Task<IList<VideoOfCourse>> GetVideoOfCourseByCourseIdAsync(MetaQueryModel metaQuery, long courseId);
    Task<VideoOfCourse> GetVideoOfCourseByIdAsync(long id);
    Task<VideoOfCourse> UpdateVideoOfCourseAsync(VideoOfCourse videoOfCourse);
    Task<VideoOfCourse> DeleteVideoOfCourseAsync(long id);
}
