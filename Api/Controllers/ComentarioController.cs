using CoreShared.modelsView.comentarios;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioManager _manager;

        public ComentarioController(IComentarioManager manager)
        {
            _manager = manager;
        }

        // GET: api/<PersonagemController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(await _manager.GetAllAsync(id));
        }

        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> Post(NovoComentario novoComentario)
        {
            return Ok(await _manager.PostComentarioAsync(novoComentario));
        }
    }
}
