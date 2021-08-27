using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsApi.Models;

namespace StarWarsApi.Data
{
    public class FilmServiceMock : IFilmService
    {
        public FilmServiceMock()
        {
        }

        public Task<List<Film>> GetFilms()
        {
            var films = new List<Film>
            {
                new Film
                {
                    Created = "1970-01-01",
                    Title = "Star was film 1",
                    OpeningCrawl = "Der var en gang et eventyr",
                    EpisodeId = 4,
                    VehicleIds = new[] { 1, 2 },
                    ReleaseDate = "1970-12-01",
                    Director = "director",
                },
                new Film
                {
                    Created = "1970-01-01",
                    Title = "Star was film 2",
                    OpeningCrawl = "Der var en gang et eventyr",
                    EpisodeId = 5,
                    VehicleIds = new[] { 1, 3 },
                    ReleaseDate = "1970-12-01",
                    Director = "director",
                }
                
            };

            return Task.FromResult(films);
        }

        public async Task<Film> GetFilm(int id)
        {
            return (await GetFilms()).SingleOrDefault(film => film.EpisodeId == id);
        }

        public Task<List<Vehicle>> GetVehicles()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    Model = "Ford escord",
                    Name = "Lynet"
                },
                new Vehicle
                {
                    Id = 2,
                    Model = "Opel cadet",
                    Name = "sneglen"
                },
                new Vehicle
                {
                    Id = 3,
                    Model = "Tesla Model S",
                    Name = "Musken"
                },
            };

            return Task.FromResult(vehicles);
        }

        public async Task<List<Vehicle>> GetVehicles(int[] ids)
        {
            var vehicles = (await GetVehicles()).Where(vehicle => ids.Contains(vehicle.Id)).ToList();
            return vehicles;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return (await GetVehicles()).SingleOrDefault(vehicle => vehicle.Id == id);
        }
    }
}