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
public class SeminarVideoController(ISeminarVideoService seminarVideoService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateSeminarVideo(SeminarVideoDto Course)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.CreateSeminarVideoAsync(Course));
    }

    [HttpPost]
    public async Task<ResponseModel> CreateCategory(CategoryDto Course)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.CreateSeminarVideoCategoryAsync(Course));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllCategory([FromQuery] MetaQueryModel metaQuery)
    {
        if (Request.Query.Count == 0)
            metaQuery.Take = 1000;
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetAllSeminarVideoCategoryAsync(metaQuery));
    }

    [HttpGet]
    public async Task<ResponseModel> GetSeminarVideoByCategoryId([FromQuery] MetaQueryModel metaQuery,int categoryId)
    {
        if (Request.Query.Count == 1)
            metaQuery.Take = 1000;
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetSeminarVideoByCategoryIdAsync(metaQuery,categoryId));
    }
    
    [HttpGet]
    public async Task<ResponseModel> GetAllSeminarVideo([FromQuery] MetaQueryModel metaQuery)
    {
        if (Request.Query.Count == 0)
            metaQuery.Take = 1000;
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetAllSeminarVideoAsync(metaQuery));
    }
    
    [HttpGet]
    public async Task<ResponseModel> GetSeminarVideoWithDetails([FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetSeminarVideoWithDetailsAsync(metaQuery));
    }


    [HttpPut]
    public async Task<ResponseModel> UpdateSeminarVideo(SeminarVideo Course)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.UpdateSeminarVideoAsync(Course));
    }
    
    [HttpPut]
    public async Task<ResponseModel> UpdateCategory(Category Course)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.UpdateSeminarVideoCategoryAsync(Course));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteSeminarVideo(int id)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.DeleteSeminarVideoAsync(id));
    }
    
    [HttpDelete]
    public async Task<ResponseModel> DeleteCategory(int id)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.DeleteSeminarVideoCategoryAsync(id));
    }
}
