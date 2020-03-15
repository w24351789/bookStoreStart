using BookGUI.Infrastructure;
using BookGUI.Services.ModelDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public class ReviewRepositoryGUI : IReviewRepositoryGUI
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;

        public ReviewRepositoryGUI(HttpClient client)
        {
            _client = client;
            _baseUri = "http://localhost:5000/api";
        }

        public async Task<BookDto> GetBookForAReview(int reviewId)
        {
            BookDto book = new BookDto();

            var uri = API.Review.GetBookForAReview(_baseUri, reviewId);

            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                book = JsonConvert.DeserializeObject<BookDto>(content);
            }

            return book;
        }

        public async Task<ReviewDto> GetReviewById(int reviewId)
        {
            ReviewDto review = new ReviewDto();

            var uri = API.Review.GetReviewById(_baseUri, reviewId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                review = JsonConvert.DeserializeObject<ReviewDto>(content);
            }

            return review;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviews()
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            var uri = API.Review.GetReviews(_baseUri);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reviews = JsonConvert.DeserializeObject<IEnumerable<ReviewDto>>(content);
            }

            return reviews;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsForABook(int bookId)
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            var uri = API.Review.GetReviewsForABook(_baseUri, bookId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reviews = JsonConvert.DeserializeObject<IEnumerable<ReviewDto>>(content);
            }

            return reviews;
        }
    }
}
