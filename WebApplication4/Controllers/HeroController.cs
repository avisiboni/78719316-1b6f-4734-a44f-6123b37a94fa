using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeBL;
using storeModel;
using System.Security.Claims;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _HeroService;
        public HeroController(IHeroService heroBL) { _HeroService = heroBL; }
        [HttpPost]
        [Authorize]
        public IActionResult AddNewHero([FromBody] Hero hero)
        {
           
            // TODO : add the login user as trainer
            _HeroService.AddHero(hero);
            return Ok();

        }
    }
}
