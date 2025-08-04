using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class VideoOfCourseController(IVideoOfCourseService videoOfCourseService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateVideoOfCourse(VideosOfCourseDto Course)
    {
        return ResponseModel
            .ResultFromContent(await videoOfCourseService.CreateVideoOfCourseAsync(Course));
    }

    [HttpGet]
    public async Task<ResponseModel> GetVideoOfCourseById(int id)
    {
        return ResponseModel
            .ResultFromContent(await videoOfCourseService.GetVideoOfCourseByIdAsync(id));
    }
    
    [HttpGet]
    public async Task<ResponseModel> GetVideoOfCourseByCourseId([FromQuery] int courseId,[FromQuery]MetaQueryModel metaQuery)
    {
        if (Request.Query.Count == 1)
            metaQuery.Take = 1000;

        return ResponseModel
            .ResultFromContent(await videoOfCourseService.GetVideoOfCourseByCourseIdAsync(metaQuery,courseId));
    }
    
    [HttpGet]
    public async Task<ResponseModel> GetAllVideoOfCourse([FromQuery]  MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await videoOfCourseService.GetAllVideoOfCourseAsync(metaQuery));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateVideoOfCourse(VideoOfCourse Course)
    {
        return ResponseModel
            .ResultFromContent(await videoOfCourseService.UpdateVideoOfCourseAsync(Course));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteVideoOfCourse(int id)
    {
        return ResponseModel
            .ResultFromContent(await videoOfCourseService.DeleteVideoOfCourseAsync(id));
    }
}
