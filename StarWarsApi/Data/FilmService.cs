using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsApi.Models;

namespace StarWarsApi.Data
{
    public interface IFilmService
    {
        Task<List<Film>> GetFilms();
        Task<Film> GetFilm(int id);
        Task<List<Vehicle>> GetVehicles();
        Task<List<Vehicle>> GetVehicles(int[] ids);
        Task<Vehicle> GetVehicle(int id);
    }

    public class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Film>> GetFilms()
        {
            var uri = "https://swapi.dev/api/films/";
            var responseString = await _httpClient.GetStringAsync(uri);
            var responseWithMetadata = JsonConvert.DeserializeObject<SwapiCollectionResponse<Film>>(responseString);
            var films = responseWithMetadata.Results;
            films.ForEach(f => f.VehicleIds = GetIdsFromUrls(f.VehicleUrls));

            return films;
        }

        public async Task<Film> GetFilm(int id)
        {
            var uri = $"https://swapi.dev/api/films/{id}";
            var responseString = await _httpClient.GetStringAsync(uri);
            var film = JsonConvert.DeserializeObject<Film>(responseString);
            film.VehicleIds = GetIdsFromUrls(film.VehicleUrls);

            return film;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            var uri = "https://swapi.dev/api/vehicles/";
            var responseString = await _httpClient.GetStringAsync(uri);
            var responseWithMetadata = JsonConvert.DeserializeObject<SwapiCollectionResponse<Vehicle>>(responseString);
            return responseWithMetadata.Results;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            var uri = $"https://swapi.dev/api/vehicles/{id}";
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<Vehicle>(responseString);
        }

        public async Task<List<Vehicle>> GetVehicles(int[] ids)
        {
            var vehicleList = new List<Vehicle>();

            foreach (var id in ids)
            {
                var vehicle = await GetVehicle(id);
                vehicleList.Add(vehicle);
            }

            return vehicleList;
        }

        private static int[] GetIdsFromUrls(string[] swapiUris)
        {
            return new List<string>(swapiUris)
                .Select(uri => SwapiUriToId(uri))
                .ToArray<int>();
        }

        private static int SwapiUriToId(string swapiUri)
        {
            return Int32.Parse(Regex.Match(swapiUri, @"\d+").Value);
        }
    }
}

