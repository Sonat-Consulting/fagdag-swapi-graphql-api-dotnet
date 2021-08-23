using Newtonsoft.Json;

namespace StarWarsApi.Models
{
    public class Film
    {
        public string Title { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        public string Created { get; set; }
        public string Edited { get; set; }

        public string Url { get; set; }

        public string[] Species { get; set; }

        public string[] Starships { get; set; }

        public string[] Vehicles { get; set; }

        public string[] Characters { get; set; }

        public string[] Planets { get; set; }
    }
}
