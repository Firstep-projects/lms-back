using Entity.Models.Learning;

namespace LearningService.Services;

public interface IItemOfCourseService
{
    Task<CourseItem> CreateItemOfCourseAsync(CourseItem itemOfCourse, long userId);
    Task<IList<CourseItem>> GetItemOfCourseByModuleIdAsync(MetaQueryModel metaQuery, long courseId);
    Task<CourseItem> GetItemOfCourseByIdAsync(long id);
    Task<CourseItem> UpdateItemOfCourseAsync(CourseItem itemOfCourse, long userid);
    Task<CourseItem> DeleteItemOfCourseAsync(long id, long userId);
}
