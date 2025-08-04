using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class SearchController(
    IArticleService articleService,
    ICourseService courseService,
    IShortVideoService shortVideoService,
    ISeminarVideoService seminarVideoService)
    : ApiControllerBase
{
    [HttpGet]
    public async Task<ResponseModel> GetShortVideoCategoryId([FromQuery] int categoryId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await shortVideoService.GetShortVideoByCategoryIdAsync(metaQuery, categoryId));
    }
    [HttpGet]
    public async Task<ResponseModel> GetShortVideoByAuthorId([FromQuery] int authorId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await shortVideoService.GetShortVideoByAftorIdAsync(metaQuery, authorId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetShortVideoByHashtagId([FromQuery] int id, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await shortVideoService.GetShortVideoByHashtagIdAsync(metaQuery, id));
    }

    [HttpGet]
    public async Task<ResponseModel> GetArticleCategoryId([FromQuery] int categoryId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await articleService.GetAllArticleByCategoryIdAsync(metaQuery, categoryId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetArticleByAuthorId([FromQuery] int authorId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await articleService.GetAllArticleByAuthorIdAsync(metaQuery, authorId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetArticleByHashtagId([FromQuery] int hashtagId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await articleService.GetAllArticleByHashtagIdAsync(metaQuery, hashtagId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetCourseCategoryId([FromQuery] int categoryId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetAllCourseByCategoryIdAsync(metaQuery, categoryId)); 
    }

    [HttpGet]
    public async Task<ResponseModel> GetCourseByAuthorId([FromQuery] int authorId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetAllCourseByAuthorIdAsync(metaQuery, authorId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetCourseByHashtagId([FromQuery] int hashtagId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await courseService.GetAllCourseByHashtagIdAsync(metaQuery, hashtagId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetSeminarVideoCategoryId([FromQuery] int categoryId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetSeminarVideoByCategoryIdAsync(metaQuery, categoryId));
    }
    [HttpGet]
    public async Task<ResponseModel> GetSeminarVideoByAuthorId([FromQuery] int authorId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetAllSeminarVideoByAuthorIdAsync(metaQuery, authorId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetSeminarVideoByHashtagId([FromQuery] int hashtagId, [FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await seminarVideoService.GetAllSeminarVideoByHashtagIdAsync(metaQuery, hashtagId));
    }
}
