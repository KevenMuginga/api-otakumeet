using CoreShared.modelsView.Animes;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeManager _manager;

        public AnimeController(IAnimeManager manager)
        {
            _manager = manager;
        }

        // GET: api/<AnimeController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _manager.GetAllAsync());
        }

        // GET api/<AnimeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // POST api/<AnimeController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoAnime novoAnime)
        {
            return Ok(await _manager.PostAnimeAsync(novoAnime));
        }

        // PUT api/<AnimeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(AlterarAnime alterarAnime)
        {
            return Ok(await _manager.PutAnimeAsync(alterarAnime));
        }

        // DELETE api/<AnimeController>/5
        [HttpDelete("{id}")]
        public void Delete()
        {

        }
    }
}
