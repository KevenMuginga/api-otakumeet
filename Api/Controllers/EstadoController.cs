using CoreShared.modelsView.estados;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoManager _manager;

        public EstadoController(IEstadoManager manager)
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
        public async Task<IActionResult> Post(NovoEstado novoEstado)
        {
            return Ok(await _manager.PostPostAsync(novoEstado));
        }

        // PUT api/<PersonagemController>/5
        [HttpPut]
        public async Task<IActionResult> Put(AlterarEstado alterarEstado)
        {
            return Ok(await _manager.PutPostAsync(alterarEstado));
        }

        // DELETE api/<PersonagemController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _manager.DeleteAsync(id);
        }
    }
}
