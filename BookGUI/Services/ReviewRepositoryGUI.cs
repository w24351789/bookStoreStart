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

        public Task<ReviewDto> GetReviewById(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewDto>> GetReviews()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewDto>> GetReviewsForABook(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
