
using storeDAL;
using storeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace storeBL
{
    public interface IHeroService
    { 
        public void AddHero(Hero hero);
        public void RemoveHero(string HeroName);
        public bool UpdateHero(Hero hero);
        public List<Hero> GetAllHeroes();
    }
    public class HeroService: IHeroService
    {

        private readonly IHeroManager _IHeroManager;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        public HeroService(IHeroManager IHeroManager,IHttpContextAccessor httpContextAccessor) { 
            _IHeroManager = IHeroManager;
            _HttpContextAccessor = httpContextAccessor;
        }
        public void AddHero(Hero hero)
        {
            var identity = _HttpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                // IEnumerable<Claim> claims = identity.Claims;
                var user = identity.FindFirst("ClaimName").Value;
               // var usernameClaim = claims.Where(x => x.Type == ClaimTypes.Name) .FirstOrDefault();
            }
            _IHeroManager.AddHero(hero);
        }
        public void RemoveHero(string HeroName)
        {
            _IHeroManager.RemoveHero(HeroName);
        }
        public bool UpdateHero(Hero hero)
        {
            return _IHeroManager.UpdateHero(hero);
        }
        public List<Hero> GetAllHeroes()
        {
            return _IHeroManager.GetAllHeroes();
        }


    }
}
