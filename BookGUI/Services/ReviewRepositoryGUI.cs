using BookGUI.Services.ModelDTOs;
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

        public Task<BookDto> GetBookForAReview(int reviewId)
        {
            throw new NotImplementedException();
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
