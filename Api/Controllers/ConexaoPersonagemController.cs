using CoreShared.modelsView.conexoes;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConexaoPersonagemController : ControllerBase
    {
        private readonly IConexaoPersonagemManager _manager;

        public ConexaoPersonagemController(IConexaoPersonagemManager manager)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _manager.GetByIdAsync(id));
        }

        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> Post(NovaConexao novaConexao)
        {
            return Ok(await _manager.PostAsync(novaConexao));
        }

        // POST api/<PersonagemController>
        [HttpPut]
        public async Task<IActionResult> Put(AlterarConexao alterarConexao)
        {
            var result = await _manager.PutAsync(alterarConexao);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
