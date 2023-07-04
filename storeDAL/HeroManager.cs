using storeModel;

namespace storeDAL
{
    public interface IHeroManager
    {
        public void AddHero(Hero Hero);
        public void RemoveHero(string HeroName);
        public bool UpdateHero(Hero Hero);
        public List<Hero> GetAllHeroes();
        public List<Hero> GetHeroByUsers();


    }
    public class HeroManager : IHeroManager
    {
        private readonly DBContext _entityContext;
        public HeroManager(DBContext entityContext) { _entityContext = entityContext; }
        public void AddHero(Hero Hero) {


            Hero.Id = Guid.NewGuid();
            
            _entityContext.Heros.Add(Hero);
            _entityContext.SaveChanges();
            
        } 
public void RemoveHero(string HeroName)
        {
           
            
                Hero? hero = new Hero() { };
                hero = _entityContext.Heros.Where(a => a.Name == HeroName).FirstOrDefault();
                if (hero != null)
                {
                _entityContext.Heros.Remove(hero);
               _entityContext .SaveChanges();
                }
                else
                { //write to log
                }

            
        }
        public bool UpdateHero(Hero Hero)
        {
            Hero? hero= new Hero();
           
                 hero = _entityContext.Heros.Where(a => a.Name == Hero.Name).FirstOrDefault();
                if (hero != null)
                {
                    hero.Name = Hero.Name;
                    hero.ability = Hero.ability;
                    hero.StartTrain =    Hero.StartTrain;
                    hero.SuitColor = Hero.SuitColor;
                    hero.StartingPower = Hero.StartingPower;
                    hero.CurrentPower = Hero.CurrentPower; 
            
                    hero.ability = Hero.ability;
                    hero.StartTrain = Hero.StartTrain;
                    hero.SuitColor = Hero.SuitColor;
                    hero.StartingPower = Hero.StartingPower;
                    hero.CurrentPower = Hero.CurrentPower;
                    hero.Trainer = Hero.Trainer;
                _entityContext.SaveChanges();
                    return true;
                }
                else
                { return false; }

            
        }
public List<Hero> GetAllHeroes() {
        List<Hero> list = new List<Hero>();
           
              list= _entityContext.Heros.ToList();

            
                return list; }
public List<Hero> GetHeroByUsers() { return new List<Hero>(); }


    }
}