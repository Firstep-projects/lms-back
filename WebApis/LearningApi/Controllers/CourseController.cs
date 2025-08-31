using Entity.DataTransferObjects.Learning;
using Entity.Models.ApiModels;
using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController(ICourseService courseService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateCourse(CourseDto course)
    {
        return ResponseModel
            .ResultFromContent(await courseService.CreateCourseAsync(course, UserId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllCourse([FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetAllCourseAsync(metaQuery));
    }
    [HttpGet]
    public async Task<ResponseModel> GetAllCourseByCategoryId([FromQuery] MetaQueryModel metaQuery,[FromQuery]int categoryId)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetAllCourseByCategoryIdAsync(metaQuery,categoryId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetCourseById(int id)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetCourseByIdAsync(id));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateCourse(Course course)
    {
        return ResponseModel
            .ResultFromContent(await courseService.UpdateCourseAsync(course, UserId));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteCourse(int id)
    {
        return ResponseModel
            .ResultFromContent(await courseService.DeleteCourseAsync(id, UserId));
    }
    [HttpPost]
    public async Task<ResponseModel> CreateModule(ModuleDto moduleDto)
    {
        return ResponseModel
            .ResultFromContent(await courseService.CreateModuleAsync(moduleDto, UserId));
    }
    [HttpGet]
    public async Task<ResponseModel> GetAllModuleByCourseId([FromQuery] MetaQueryModel metaQuery,[FromQuery]int courseId)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetAllModuleByCourseIdAsync(metaQuery,courseId));
    }
    [HttpDelete]
    public async Task<ResponseModel> DeleteModule(int id)
    {
        return ResponseModel
            .ResultFromContent(await courseService.DeleteModuleAsync(id, UserId));
    }
    [HttpPut]
    public async Task<ResponseModel> UpdateModule(ModuleDto moduleDto)
    {
        return ResponseModel
            .ResultFromContent(await courseService.UpdateModuleAsync(moduleDto, UserId));
    }
}
