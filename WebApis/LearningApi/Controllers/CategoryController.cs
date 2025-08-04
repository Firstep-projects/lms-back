using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController(ISeminarVideoService seminarVideoService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateCategory(CategoryDto Course)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.CreateSeminarVideoCategoryAsync(Course));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllCategory([FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetAllSeminarVideoCategoryAsync(metaQuery));
    }

    [HttpGet]
    public async Task<ResponseModel> GetCategoryById(int categoryId)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetCategoryById(categoryId));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateCategory(Category Course)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.UpdateSeminarVideoCategoryAsync(Course));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteCategory(int id)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.DeleteSeminarVideoCategoryAsync(id));
    }
}
