using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsApi.Models;

namespace StarWarsApi.Data
{
    public interface IFilmService
    {
        Task<List<Film>> GetFilms();
        Task<Film> GetFilm(int episodeId);
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
            return responseWithMetadata.Results;
        }

        public async Task<Film> GetFilm(int id)
        {
            var uri = $"https://swapi.dev/api/films/{id}";
            var responseString = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<Film>(responseString);
        }
    }

    public class SwapiCollectionResponse<T>
    {
        public int Count { get; set; }

        public int? Next { get; set; }

        public int? Previous { get; set; }

        public List<T> Results { get; set; }
    }
}

