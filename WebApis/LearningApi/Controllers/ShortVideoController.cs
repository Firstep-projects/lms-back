using Entity.DataTransferObjects.Learning;
using Entity.Models.Learning;
using LearningService.Services;
using Microsoft.AspNetCore.Mvc;
using WebCore.Controllers;
using WebCore.Models;

namespace LearningApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShortVideoController(IShortVideoService shortVideoService) : ApiControllerBase
    {
        [HttpPost]
        public async Task<ResponseModel> CreateShortVideo(ShortVideoDto shortVideoDto)
        {
            return ResponseModel
                .ResultFromContent(await shortVideoService.CreateShortVideoAsync(shortVideoDto));
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllShortVideo([FromQuery] MetaQueryModel metaQuery)
        {
            if (Request.Query.Count == 0)
                metaQuery.Take = 1000;

            return ResponseModel
                .ResultFromContent(await shortVideoService.GetAllShortVideoAsync(metaQuery));
        }
        
        [HttpGet]
        public async Task<ResponseModel> GetAllShortVideoWithDetails([FromQuery] MetaQueryModel metaQuery)
        {
            if (Request.Query.Count == 0)
                metaQuery.Take = 1000;

            return ResponseModel
                .ResultFromContent(await shortVideoService.GetShortVideoWithDetailsAsync(metaQuery));
        }
        
        [HttpGet]
        public async Task<ResponseModel> GetShortVideoCategoryId([FromQuery] int categoryId,[FromQuery] MetaQueryModel metaQuery)
        {
            if (Request.Query.Count == 1)
                metaQuery.Take = 1000;

            return ResponseModel
                .ResultFromContent(await shortVideoService.GetShortVideoByCategoryIdAsync(metaQuery,categoryId));
        }
        [HttpGet]
        public async Task<ResponseModel> GetShortVideoByAuthorId([FromQuery] int authorId,[FromQuery] MetaQueryModel metaQuery)
        {
            if (Request.Query.Count == 1)
                metaQuery.Take = 1000;

            return ResponseModel
                .ResultFromContent(await shortVideoService.GetShortVideoByAftorIdAsync(metaQuery,authorId));
        }

        [HttpGet]
        public async Task<ResponseModel> GetShortVideoByHashtagId([FromQuery]  int id,[FromQuery] MetaQueryModel metaQuery)
        {
            if (Request.Query.Count == 1)
                metaQuery.Take = 1000;

            return ResponseModel
                .ResultFromContent(await shortVideoService.GetShortVideoByHashtagIdAsync(metaQuery,id));
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateShortVideo(ShortVideo shortVideo)
        {
            return ResponseModel
                .ResultFromContent(await shortVideoService.UpdateShortVideoAsync(shortVideo));
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteShortVideo(int id)
        {
            return ResponseModel
                .ResultFromContent(await shortVideoService.DeleteShortVideoAsync(id));
        }
 
    }
}
