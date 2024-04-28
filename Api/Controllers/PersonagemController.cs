using Core.domain;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.usuarios;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly UserManager<Personagem> _userManager;
        private readonly IPersonagemManager _manager;

        public PersonagemController(IPersonagemManager manager)
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

        // GET api/<PersonagemController>/5
        [HttpGet("AnimeWithoutUser/{animeId}")]
        public async Task<IActionResult> GetByAllAnimeIdWUserId(int animeId)
        {
            return Ok(await _manager.GetAllByAnimeWithoutUserAsync(animeId));
        }

        // GET api/<PersonagemController>/5
        [HttpGet("Anime/{animeId}")]
        public async Task<IActionResult> GetAllByAnimeId(int animeId)
        {
            return Ok(await _manager.GetAllByAnimeAsync(animeId));
        }


        // POST api/<PersonagemController>
        [HttpPost]
        public async Task<IActionResult> Post(NovaPersonagem novaPersonagem)
        {
            var result = await _manager.PostPersnoangemAsync(novaPersonagem);
            if (result.Id == null)
            {

            }
            //await _userManager.AddClaimAsync(result, new Claim(ClaimTypes.Name, result.Nome));
            return Ok(result);
        }

        [HttpPost("Follow")]
        public async Task Follow(Follow follow)
        {
            await _manager.FollowPersonagemAsync(follow);
        }

        [HttpPut("StopFollow")]
        public async Task UnFollow(Follow follow)
        {
            await _manager.StopFollowPersonagemAsync(follow);
        }

        [HttpGet("Following/{id}")]
        public async Task<IActionResult> Following(int id)
        {
            return Ok(await _manager.GetAllFollowingPersonageAsync(id));
        }

        [HttpGet("UnFollowing/{id}")]
        public async Task<IActionResult> UnFollowing(int id)
        {
            return Ok(await _manager.GetAllUnfofllowingPersonageAsync(id));
        }
    }
}
