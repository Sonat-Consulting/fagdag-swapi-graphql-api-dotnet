using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsApi.Models;

namespace StarWarsApi.Data
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviews();
        Task<List<Review>> GetReviews(int episodeId);

        Task<Review> AddReview(Review review);
    }

    public class ReviewService : IReviewService
    {
        private List<Review> _reviews;

        public async Task<List<Review>> GetReviews()
        {
            if (_reviews == null)
            {
                this._reviews = await ReadReviewsFromFile();
            }
            return this._reviews;
        }

        public async Task<List<Review>> GetReviews(int episodeId)
        {
            var allReviews = await this.GetReviews();
            return allReviews.Where(r => r.EpisodeId == episodeId).ToList<Review>();
        }

        public async Task<Review> AddReview(Review review)
        {
            (await GetReviews()).Add(review);
            return review;
        }

        private async Task<List<Review>> ReadReviewsFromFile()
        {
            var entireFile = await System.IO.File.ReadAllTextAsync("./Resources/reviews.json");
            return JsonConvert.DeserializeObject<List<Review>>(entireFile);
        }
    }
}