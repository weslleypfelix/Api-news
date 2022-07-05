using Api_newss.Entities.ViewModels;
using Api_newss.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api_newss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {

        private readonly ILogger<NewsController> _logger;
        private readonly NewService _newsService;

        public NewsController(ILogger<NewsController> logger, NewService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult<List<NewsViewModel>> Get() => _newsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetNews")]
        public ActionResult<NewsViewModel> Get(string id)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            return news;
        }

        [HttpPost]
        public ActionResult<NewsViewModel> Create(NewsViewModel news)
        {
            var result = _newsService.Create(news);

            return CreatedAtRoute("GetNews", new { id = result.Id.ToString() }, result);
        }


        [HttpPut("{id:length(24)}")]
        public ActionResult<NewsViewModel> Update(string id, NewsViewModel newsIn)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            _newsService.Update(id, newsIn);

            return CreatedAtRoute("GetNews", new { id = id }, newsIn);

        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            _newsService.Remove(news.Id);

            return Ok("Noticia deletada com sucesso!");
        }


    }
}
