using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostManager _manager;

        public PostController(IPostManager manager)
        {
            this._manager = manager;
        }

        // GET: api/<PersonagemController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manager.GetAllAsync());
        }

        // GET api/<PersonagemController>/5
        [HttpGet("Personagem/{id}")]
        public async Task<IActionResult> GetByAllOfPersonagem(int id)
        {
            return Ok(await _manager.GetAllPostByPersonagemAsync(id));
        }

        // GET api/<PersonagemController>/5
        [HttpGet("PersonagesFollowing/{id}")]
        public async Task<IActionResult> GetAllPostOfPersonagesFollowingAsync(int id)
        {
            return Ok(await _manager.GetAllPostOfPersonagesFollowingAsync(id));
        }

        // GET api/<PersonagemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // GET api/<PersonagemController>/5
        [HttpGet("All/{keyWord}")]
        public async Task<IActionResult> Search(string keyWord)
        {
            return Ok(await _manager.Search(keyWord));
        }


        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoPost novoPost)
        {
            return Ok(await _manager.PostPostAsync(novoPost));
        }

        // POST api/<PersonagemController>
        [HttpPost("AddEstrela")]
        public async Task<IActionResult> AddEstrela(AddEstrela addEstrela)
        {
            return Ok(await _manager.AddeRemoveEstarelaPostAsync(addEstrela));
        }

        // PUT api/<PersonagemController>/5
        [HttpPut]
        public async Task<IActionResult> Put(AlterarPost alterarPost)
        {
            return Ok(await _manager.PostPostAsync(alterarPost));
        }

        // DELETE api/<PersonagemController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _manager.DeleteAsync(id);
        }

        // POST api/<PersonagemController>
        [HttpDelete("RemoveEstrela")]
        public async Task RemoveEstrela(AddEstrela addEstrela)
        {
            await _manager.RemoveEstrelaAsync(addEstrela);
        }
    }
}
