using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsApi.Models;

namespace StarWarsApi.Data
{
    public interface IFilmsReposity
    {
        Task<IEnumerable<Film>> GetAll();
    }
    
    public class FilmsRepository : IFilmsReposity
    {
        public Task<IEnumerable<Film>> GetAll()
        {
            return Task.FromResult(new Film[]
            {
                new()
                {
                    Title = "A New Hope", 
                    Id = 1, 
                    EpisodeId = 4, 
                    OpeningCrawl = "It is a period of civil war.\r\nRebel spaceships, striking\r\nfrom a hidden base, have won\r\ntheir first victory against\r\nthe evil Galactic Empire.\r\n\r\nDuring the battle, Rebel\r\nspies managed to steal secret\r\nplans to the Empire's\r\nultimate weapon, the DEATH\r\nSTAR, an armored space\r\nstation with enough power\r\nto destroy an entire planet.\r\n\r\nPursued by the Empire's\r\nsinister agents, Princess\r\nLeia races home aboard her\r\nstarship, custodian of the\r\nstolen plans that can save her\r\npeople and restore\r\nfreedom to the galaxy....", 
                    Director = "George Lucas",
                    Producer = "Gary Kurtz, Rick McCallum",
                    ReleaseDate = "1977-05-25"
                },
                new()
                {
                    Title = "The Empire Strikes Back",
                    Id = 2,
                    EpisodeId = 5,
                    OpeningCrawl = "It is a dark time for the\r\nRebellion. Although the Death\r\nStar has been destroyed,\r\nImperial troops have driven the\r\nRebel forces from their hidden\r\nbase and pursued them across\r\nthe galaxy.\r\n\r\nEvading the dreaded Imperial\r\nStarfleet, a group of freedom\r\nfighters led by Luke Skywalker\r\nhas established a new secret\r\nbase on the remote ice world\r\nof Hoth.\r\n\r\nThe evil lord Darth Vader,\r\nobsessed with finding young\r\nSkywalker, has dispatched\r\nthousands of remote probes into\r\nthe far reaches of space....",
                    Director = "Irvin Kershner",
                    Producer = "Gary Kurtz, Rick McCallum",
                    ReleaseDate = "1980-05-17"
                }
            }.AsEnumerable());
        }
    }
}