using Newtonsoft.Json;

namespace StarWarsApi.Models
{
    public class Film
    {
        public string Title { get; set; }

        public int Id { get; set; }

        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
    }
}