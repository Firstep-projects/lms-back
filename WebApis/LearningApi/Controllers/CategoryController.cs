﻿using DatabaseBroker.Repositories.Learning;
using Entity.DataTransferObjects.Learning;
using Entity.Models.ApiModels;
using Entity.Models.Learning;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController(ISeminarVideoService seminarVideoService) : ApiControllerBase
{
    private readonly ISeminarVideoService _seminarVideoService = seminarVideoService;

    [HttpPost]
    public async ValueTask<ResponseModel> CreateCategory(CategoryDto Course)
    {
        return ResponseModel
            .ResultFromContent(await _seminarVideoService.CreateSeminarVideoCategoryAsync(Course));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllCategory([FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await _seminarVideoService.GetAllSeminarVideoCategoryAsync(metaQuery));
    }

    [HttpGet]
    public async ValueTask<ResponseModel> GetCategoryById(int categoryId)
    {
        return ResponseModel
            .ResultFromContent(await _seminarVideoService.GetCategoryById(categoryId));
    }

    [HttpPut]
    public async ValueTask<ResponseModel> UpdateCategory(Category Course)
    {
        return ResponseModel
            .ResultFromContent(await _seminarVideoService.UpdateSeminarVideoCategoryAsync(Course));
    }

    [HttpDelete]
    public async ValueTask<ResponseModel> DeleteCategory(int id)
    {
        return ResponseModel
            .ResultFromContent(await _seminarVideoService.DeleteSeminarVideoCategoryAsync(id));
    }
}
