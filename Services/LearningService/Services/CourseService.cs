using DatabaseBroker.Repositories;
using Entity.DataTransferObjects.Learning;
using Entity.Exceptions;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore;

namespace LearningService.Services;

public class CourseService(
    GenericRepository<Course, long> courseRepository,
    GenericRepository<Module, long> moduleRepository)
    : ICourseService
{
    public async Task<Course> CreateCourseAsync(CourseDto courseDto, long userId)
    {
        var newCourse = new Course
        {
            Title = courseDto.title,
            Description = courseDto.description,
            Image = courseDto.image,
            LanguageCode = courseDto.languageCode,
            AuthorId = courseDto.authorId,
            CategoryId = courseDto.categoryId,
            CreatedBy = userId,
        };

        return await courseRepository.AddWithSaveChangesAsync(newCourse);
    }
    public async Task<Course> DeleteCourseAsync(long courseId, long userId)
    {
        var courseResult = await courseRepository.GetByIdAsync(courseId)
            ?? throw new NotFoundException("Not found");
        
        courseResult.UpdatedBy = userId;

        return await courseRepository.RemoveWithSaveChangesAsync(courseId);
    }
    public async Task<IList<Course>> GetAllCourseAsync(MetaQueryModel metaQuery)
    {
        var courses = await courseRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(c => new Course()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Image = c.Image,
                LanguageCode = c.LanguageCode,
                AuthorId = c.AuthorId,
                Author = new Author(){Id = c.Author.Id,Name = c.Author.Name,Content = c.Author.Content,ImageLink = c.Author.ImageLink},
                CategoryId = c.CategoryId,
                Category = new Category(){Id = c.Category.Id,Title = c.Category.Title,Description = c.Category.Description,ImageLink = c.Category.ImageLink},
            })
            .ToListAsync();

        return courses;
    }
    public async Task<IList<Course>> GetAllCourseByCategoryIdAsync(MetaQueryModel metaQuery,long categoryId)
    {
        var courses = await courseRepository
            .GetAllAsQueryable()
            .Where(c => c.CategoryId == categoryId)
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(c => new Course()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Image = c.Image,
                LanguageCode = c.LanguageCode,
                AuthorId = c.AuthorId,
                Author = new Author(){Id = c.Author.Id,Name = c.Author.Name,Content = c.Author.Content,ImageLink = c.Author.ImageLink},
                CategoryId = c.CategoryId,
                Category = new Category(){Id = c.Category.Id,Title = c.Category.Title,Description = c.Category.Description,ImageLink = c.Category.ImageLink},
            })
            .ToListAsync();

        return courses;
    }
    public async Task<IList<Course>> GetAllCourseByAuthorIdAsync(MetaQueryModel metaQuery, long authorId)
    {
        var newCourse = await courseRepository
           .GetAllAsQueryable()
           .Where(x => x.AuthorId == authorId)
           .Skip(metaQuery.Skip)
           .Select(c => new Course()
           {
               Id = c.Id,
               Title = c.Title,
               Description = c.Description,
               Image = c.Image,
               AuthorId = c.AuthorId,
               Author = new Author() { Id = c.Author.Id, Name = c.Author.Name, ImageLink = c.Author.ImageLink },
               CategoryId = c.CategoryId,
               Category = new Category() { Id = c.Category.Id, Title = c.Category.Title, ImageLink = c.Category.ImageLink },
           })
           .Take(metaQuery.Take)
           .ToListAsync();
        
        return newCourse;
    }
    public async Task<IList<Course>> GetAllCourseByHashtagIdAsync(MetaQueryModel metaQuery, long hashtagId)
    {
        var newCourse = await courseRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(c => new Course()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Image = c.Image,
                LanguageCode = c.LanguageCode,
                AuthorId = c.AuthorId,
                Author = new Author() { Id = c.Author.Id, Name = c.Author.Name,  ImageLink = c.Author.ImageLink },
                CategoryId = c.CategoryId,
                Category = new Category() { Id = c.Category.Id, Title = c.Category.Title, ImageLink = c.Category.ImageLink },
            })
            .ToListAsync();

        return newCourse;
    }
    public async Task<Course> GetCourseByIdAsync(long id)
    {
        var courseResult = await courseRepository
                .GetAllAsQueryable(true)
                .Select(c => new Course()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Image = c.Image,
                    LanguageCode = c.LanguageCode,
                    AuthorId = c.AuthorId,
                    Author = new Author(){Id = c.Author.Id,Name = c.Author.Name,Content = c.Author.Content,ImageLink = c.Author.ImageLink},
                    CategoryId = c.CategoryId,
                    Category = new Category(){Id = c.Category.Id,Title = c.Category.Title,Description = c.Category.Description,ImageLink = c.Category.ImageLink},
                })
                .FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new NotFoundException("Not found");

         return courseResult;
    }
    public async Task<Course> UpdateCourseAsync(Course course, long userId)
    {
        var courseResult = await courseRepository.GetByIdAsync(course.Id)
            ?? throw new NotFoundException("Not found");

        courseResult.Title = course.Title ?? courseResult.Title;
        courseResult.Description = course.Description ?? courseResult.Description;
        courseResult.Image = course.Image ?? courseResult.Image;
        courseResult.LanguageCode = course.LanguageCode ?? courseResult.LanguageCode;
        courseResult.AuthorId = (course.AuthorId != 0) ? course.AuthorId : courseResult.AuthorId;
        courseResult.CategoryId = (course.CategoryId != 0) ? course.CategoryId : courseResult.CategoryId;
        courseResult.UpdatedBy = userId;
        
        return await courseRepository.UpdateWithSaveChangesAsync(courseResult);
    }
    public async Task<ModuleDto> CreateModuleAsync(ModuleDto moduleDto, long userId)
    {
        var newModule = new Module()
        {
            Title = moduleDto.Title,
            Description = moduleDto.Description,
            CourseId = moduleDto.CourseId,
            Duration = moduleDto.Duration,
            CreatedBy = userId,
        };

        var module = await moduleRepository.AddWithSaveChangesAsync(newModule);
        //moduleDto.Id = module.Id;
        return moduleDto;
    }
    public async Task<Module> DeleteModuleAsync(long moduleId, long userId)
    {
        var module = await moduleRepository.GetByIdAsync(moduleId)
                           ?? throw new NotFoundException("Not found");
        
        module.UpdatedBy = userId;

        return await moduleRepository.RemoveWithSaveChangesAsync(moduleId);
    }
    public async Task<IList<ModuleDto>> GetAllModuleByCourseIdAsync(MetaQueryModel metaQuery,long courseId)
    {
        var modules = await moduleRepository
            .GetAllAsQueryable()
            .Where(c => c.CourseId == courseId)
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(c => new ModuleDto(
                c.Id,
                c.Title,
                c.Description,
                c.OrderNumber,
                1, 
                c.Duration,
                c.CourseId
            ))
            .ToListAsync();

        return modules;
    }
    public async Task<Module> UpdateModuleAsync(ModuleDto moduleDto, long userId)
    {
        var module = await moduleRepository.GetByIdAsync(moduleDto.Id)
                           ?? throw new NotFoundException("Not found");

        module.Title = moduleDto.Title ?? module.Title;
        module.Description = moduleDto.Description ?? module.Description;
        module.OrderNumber = moduleDto.OrderNumber > 0 ? moduleDto.OrderNumber : module.OrderNumber;
        module.Duration = moduleDto.Duration != TimeSpan.Zero ? moduleDto.Duration : module.Duration;
        module.UpdatedBy = userId;
        
        return await moduleRepository.UpdateWithSaveChangesAsync(module);
    }
}
