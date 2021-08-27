using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public FilmService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _cache = memoryCache;
        }

        public async Task<List<Film>> GetFilms()
        {
            if (_cache.TryGetValue<List<Film>>("films", out var cachedFilms))
            {
                return cachedFilms;
            }

            var uri = "http://192.168.74.149:8000/api/films/";
            var responseString = await _httpClient.GetStringAsync(uri);
            var responseWithMetadata = JsonConvert.DeserializeObject<SwapiCollectionResponse<Film>>(responseString);
            var films = responseWithMetadata.Results;
            films.ForEach(f => f.VehicleIds = GetIdsFromUrls(f.VehicleUrls));

            _cache.Set<List<Film>>("films", films);
            return films;
        }

        public async Task<Film> GetFilm(int id)
        {
            if (_cache.TryGetValue<Film>($"films-{id}", out var cachedFilms))
            {
                return cachedFilms;
            }
            var uri = $"http://192.168.74.149:8000/api/films/{id}";
            var responseString = await _httpClient.GetStringAsync(uri);
            var film = JsonConvert.DeserializeObject<Film>(responseString);
            film.VehicleIds = GetIdsFromUrls(film.VehicleUrls);

            _cache.Set<Film>($"films-{id}", film);
            return film;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            if (_cache.TryGetValue<List<Vehicle>>($"vehicles", out var cachedVehicles))
            {
                return cachedVehicles;
            }
            var uri = "http://192.168.74.149:8000/api/vehicles/";
            var responseString = await _httpClient.GetStringAsync(uri);
            var responseWithMetadata = JsonConvert.DeserializeObject<SwapiCollectionResponse<Vehicle>>(responseString);
            var vehicles = responseWithMetadata.Results;

            _cache.Set<List<Vehicle>>($"vehicles", vehicles);

            return vehicles;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            if (_cache.TryGetValue<Vehicle>($"vehicle-{id}", out var cachedVehicle))
            {
                return cachedVehicle;
            }
            var uri = $"http://192.168.74.149:8000/api/vehicles/{id}";
            var responseString = await _httpClient.GetStringAsync(uri);
            var vehicle = JsonConvert.DeserializeObject<Vehicle>(responseString);

            _cache.Set<Vehicle>($"vehicle-{id}", vehicle);

            return vehicle;
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

