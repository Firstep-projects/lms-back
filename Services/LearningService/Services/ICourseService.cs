using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;

namespace LearningService.Services;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseDto courseDto, long userId);
    Task<Course> UpdateCourseAsync(Course course, long userId);
    Task<Course> DeleteCourseAsync(long courseId, long userId);
    Task<Course> GetCourseByIdAsync(long id);
    Task<IList<Course>> GetAllCourseAsync(MetaQueryModel metaQuery);
    Task<IList<Course>> GetAllCourseByAuthorIdAsync(MetaQueryModel metaQuery,long authorId);
    Task<IList<Course>> GetAllCourseByHashtagIdAsync(MetaQueryModel metaQuery, long hashtagId);
    Task<IList<Course>> GetAllCourseByCategoryIdAsync(MetaQueryModel metaQuery, long categoryId);
    Task<ModuleDto> CreateModuleAsync(ModuleDto moduleDto, long userId);
    Task<Module> DeleteModuleAsync(long moduleId, long userId);
    Task<IList<ModuleDto>> GetAllModuleByCourseIdAsync(MetaQueryModel metaQuery, long courseId);
    Task<Module> UpdateModuleAsync(ModuleDto moduleDto, long userId);
}