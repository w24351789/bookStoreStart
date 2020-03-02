using BookGUI.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services.ModelDTOs
{
    public class ReviewerRepositoryGUI : IReviewerRepositoryGUI
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;

        public ReviewerRepositoryGUI(HttpClient client)
        {
            _client = client;
            _baseUri = "http://localhost:5000/api";
        }

        public async Task<ReviewerDto> GetReviewerByAReview(int reviewId)
        {
            ReviewerDto reviewer = new ReviewerDto();

            var uri = API.Reviewer.GetReviewerByAReview(_baseUri, reviewId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reviewer = JsonConvert.DeserializeObject<ReviewerDto>(content);
            }

            return reviewer;
        }

        public async Task<ReviewerDto> GetReviewerById(int reviewerId)
        {
            ReviewerDto reviewer = new ReviewerDto();

            var uri = API.Reviewer.GetReviewerById(_baseUri, reviewerId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reviewer = JsonConvert.DeserializeObject<ReviewerDto>(content);
            }

            return reviewer;
        }

        public async Task<IEnumerable<ReviewerDto>> GetReviewers()
        {
            IEnumerable<ReviewerDto> reviewers = new List<ReviewerDto>();

            var uri = API.Reviewer.GetReviewers(_baseUri);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                reviewers = JsonConvert.DeserializeObject<IEnumerable<ReviewerDto>>(content);
            }

            return reviewers;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByAReviewer(int reviewerId)
        {
            IEnumerable<ReviewDto> reviews = new List<ReviewDto>();

            var uri = API.Reviewer.GetReviewsByAReviewer(_baseUri, reviewerId);

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
