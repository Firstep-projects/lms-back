using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ArticleController(IArticleService articleService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateArticle(ArticleDto article)
    {
        return ResponseModel
            .ResultFromContent(await articleService.CreateArticleAsync(article));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllArticle([FromQuery] MetaQueryModel metaQuery)
    {
        if (Request.Query.Count == 0)
            metaQuery.Take = 1000;

        return ResponseModel

            .ResultFromContent(await articleService.GetAllArticleAsync(metaQuery));
    }
    
    [HttpGet]
    public async Task<ResponseModel> GetAllArticleByCategoryId([FromQuery] MetaQueryModel metaQuery,[FromQuery]int categoryId)
    {
        if (Request.Query.Count == 0)
            metaQuery.Take = 1000;

        return ResponseModel

            .ResultFromContent(await articleService.GetAllArticleByCategoryIdAsync(metaQuery,categoryId));
    }

    [HttpGet]
    public async Task<ResponseModel> GetArticleById(int id)
    {
        return ResponseModel
            .ResultFromContent(await articleService.GetArticleByIdAsync(id));
    }
    [HttpGet]
    public async Task<ResponseModel> GetArticleWithDetails([FromQuery] MetaQueryModel metaQuery)
    {
        return ResponseModel
            .ResultFromContent(await articleService.GetArticleWithDetailsAsync(metaQuery));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateArticle(Article article)
    {
        return ResponseModel
            .ResultFromContent(await articleService.UpdateArticleAsync(article));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteArticle(int id)
    {
        return ResponseModel
            .ResultFromContent(await articleService.DeleteArticleAsync(id));
    }
}