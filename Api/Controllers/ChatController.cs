
using Core.domain;
using CoreShared.modelsView.chats;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IGrupoManager _manager;

        public ChatController(IGrupoManager manager)
        {
            this._manager = manager;
        }

        // GET: api/<PersonagemController>
        [HttpGet("Personagem/{id}")]
        public async Task<IActionResult> GetAllByPersonagemIdAsync(int id)
        {
            return Ok(await _manager.GetAllByPersonagemIdAsync(id));
        }

        // GET api/<PersonagemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // GET api/<PersonagemController>/5
        [HttpGet]
        public async Task<IActionResult> GetAllPostOfPersonagesFollowingAsync(Grupo chat)
        {
            return Ok(await _manager.get(chat));
        }

        // GET api/<PersonagemController>/5
        [HttpPost("Grupo")]
        public async Task<IActionResult> GetByGrupoAsync(NovoGrupo chat)
        {
            return Ok(await _manager.GetByGrupoAsync(chat));
        }


        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoGrupo novoChat)
        {
            return Ok(await _manager.PostAsync(novoChat));
        }

        // Delete api/<PersonagemController>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);
            return NoContent();
        }
    }
}
