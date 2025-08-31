using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ItemOfCourseController(IItemOfCourseService itemOfCourseService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateItemOfCourse(CourseItem item)
    {
        return ResponseModel
            .ResultFromContent(await itemOfCourseService.CreateItemOfCourseAsync(item, UserId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetItemOfCourseById(int id)
    {
        return ResponseModel
            .ResultFromContent(await itemOfCourseService.GetItemOfCourseByIdAsync(id));
    }
    
    [HttpGet]
    public async Task<ResponseModel> GetItemOfCourseByCourseId([FromQuery] int courseId,[FromQuery]MetaQueryModel metaQuery)
    {
        if (Request.Query.Count == 1)
            metaQuery.Take = 1000;

        return ResponseModel
            .ResultFromContent(await itemOfCourseService.GetItemOfCourseByModuleIdAsync(metaQuery,courseId));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateItemOfCourse(CourseItem item)
    {
        return ResponseModel
            .ResultFromContent(await itemOfCourseService.UpdateItemOfCourseAsync(item, UserId));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteItemOfCourse(int id)
    {
        return ResponseModel
            .ResultFromContent(await itemOfCourseService.DeleteItemOfCourseAsync(id, UserId));
    }
}
