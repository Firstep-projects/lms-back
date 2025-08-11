using Entity.DataTransferObjects.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthorController(IAuthorService authorService) : ApiControllerBase
{
    [HttpPost]
    public async Task<ResponseModel> CreateAuthor(AuthorDto author)
    {
        return ResponseModel
            .ResultFromContent(await authorService.CreateAuthorAsync(author));
    }

    [HttpGet]
    public async Task<ResponseModel> GetAllAuthor()
    {
        return ResponseModel
            .ResultFromContent(await authorService.GetAllAuthorAsync());
    }

    [HttpGet]
    public async Task<ResponseModel> GetAuthorById(int id)
    {
        return ResponseModel
            .ResultFromContent(await authorService.GetAuthorByIdAsync(id));
    }

    [HttpPut]
    public async Task<ResponseModel> UpdateAuthor(AuthorDto author)
    {
        return ResponseModel
            .ResultFromContent(await authorService.UpdateAuthorAsync(author));
    }

    [HttpDelete]
    public async Task<ResponseModel> DeleteAuthor(int id)
    {
        return ResponseModel
            .ResultFromContent(await authorService.DeleteAuthorAsync(id));
    }
}