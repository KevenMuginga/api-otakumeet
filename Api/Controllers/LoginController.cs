using CoreShared.modelsView.Animes;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.usuarios;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _manager;

        public LoginController(ILoginManager manager)
        {
            this._manager = manager;
        }

        // POST api/<AnimeController>
        [HttpPost]
        public async Task<IActionResult> Post(LoginUsuario loginUsuario)
        {
            var login = await _manager.Login(loginUsuario);
            if(login == null)
            {
                return Unauthorized();
            }
            return Ok(login);
        }
    }
}
