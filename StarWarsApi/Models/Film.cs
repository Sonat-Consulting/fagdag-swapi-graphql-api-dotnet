namespace StarWarsApi.Models
{
    public class Film
    {
        public string Title { get; set; }
        public int Id { get; set; }
        
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        
    }
}