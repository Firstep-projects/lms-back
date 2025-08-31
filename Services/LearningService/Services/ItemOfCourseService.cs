using DatabaseBroker.Repositories;
using Entity.Exceptions;
using Entity.Models.Learning;
using Microsoft.EntityFrameworkCore;

namespace LearningService.Services;

public class ItemOfCourseService(GenericRepository<CourseItem, long>  itemOfCourseRepository) : IItemOfCourseService
{
    public async Task<CourseItem> CreateItemOfCourseAsync(CourseItem itemOfCourse, long userId)
    {
        itemOfCourse.UpdatedBy = userId;
        return await itemOfCourseRepository.AddWithSaveChangesAsync(itemOfCourse);
    }
    public async Task<CourseItem> DeleteItemOfCourseAsync(long id, long userId)
    {
        var articleResult = await itemOfCourseRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Logotype not found");
        
        articleResult.UpdatedBy = userId;

        return await itemOfCourseRepository.RemoveWithSaveChangesAsync(id);
    }
    public async Task<IList<CourseItem>> GetAllItemOfCourseAsync(MetaQueryModel metaQuery)
    {
        var articles = await itemOfCourseRepository
           .GetAllAsQueryable()
           .Skip(metaQuery.Skip)
           .Take(metaQuery.Take)
           .Select(ci => new CourseItem()
           {
               Id = ci.Id,
               Title = ci.Title,
               Description = ci.Description,
               Image = ci.Image,
               Type = ci.Type
           })
           .ToListAsync();

        return articles;
    }
    public async Task<IList<CourseItem>> GetItemOfCourseByModuleIdAsync(MetaQueryModel metaQuery, long courseId)
    {
        var result = await itemOfCourseRepository
            .GetAllAsQueryable()
            .Skip(metaQuery.Skip)
            .Take(metaQuery.Take)
            .Select(ci => new CourseItem()
            {
                Id = ci.Id,
                Title = ci.Title,
                Description = ci.Description,
                Image = ci.Image,
                Type = ci.Type
            })
            .ToListAsync();

        return result;
    }
    public async Task<CourseItem> GetItemOfCourseByIdAsync(long id)
    {
        var result = await itemOfCourseRepository
            .GetByIdAsync(id);

        return result;
    }
    public async Task<CourseItem> UpdateItemOfCourseAsync(CourseItem itemOfCourse, long userId)
    {
        var result = await itemOfCourseRepository.GetByIdAsync(itemOfCourse.Id)
            ?? throw new NotFoundException("Logotype not found");
        
        return await itemOfCourseRepository.UpdateWithSaveChangesAsync(itemOfCourse);
    }
}
