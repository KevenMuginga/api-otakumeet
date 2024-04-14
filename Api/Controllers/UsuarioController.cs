using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.usuarios;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager _manager;

        public UsuarioController(IUsuarioManager manager)
        {
            _manager = manager;
        }

        // GET: api/<PersonagemController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manager.GetAllAsync());
        }

        // GET api/<PersonagemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }


        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoUsuario novoUsuario)
        {
            return Ok(await _manager.PostPersnoangemAsync(novoUsuario));
        }


        [HttpDelete]
        public async Task Delete(int id)
        {
            await _manager.DeleteUsuarioAsync(id);
        }
    }
}
