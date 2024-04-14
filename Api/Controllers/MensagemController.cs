using Core.domain;
using CoreShared.modelsView.mensagens;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemManager _manager;

        public MensagemController(IMensagemManager manager)
        {
            this._manager = manager;
        }

        // GET: api/<PersonagemController>
        [HttpGet]
        public async Task<IActionResult> GetAll(Grupo chat)
        {
            return Ok(await _manager.GetAllByChatAsync(chat));
        }

        // GET api/<PersonagemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByChatAsync(int id)
        {
            return Ok(await _manager.GetAllByChatAsync(id));
        }

        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> AddEstrela(NovaMensagem mensagem)
        {
            //_chatHub.SendPrivateMensage(mensagem);
            return Ok(await _manager.PostAsync(mensagem));
        }
    }
}
