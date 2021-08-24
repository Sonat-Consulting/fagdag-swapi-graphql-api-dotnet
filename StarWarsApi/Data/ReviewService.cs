using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsApi.Models;

namespace StarWarsApi.Data
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviews();
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

        private async Task<List<Review>> ReadReviewsFromFile()
        {
            var entireFile = await System.IO.File.ReadAllTextAsync("./Resources/reviews.json");
            return JsonConvert.DeserializeObject<List<Review>>(entireFile);
        }
    }
}