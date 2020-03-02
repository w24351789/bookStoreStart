using BookGUI.Services.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public interface IReviewerRepositoryGUI
    {
        Task<IEnumerable<ReviewerDto>> GetReviewers();
        Task<ReviewerDto> GetReviewerById(int reviewerId);
        Task<IEnumerable<ReviewDto>> GetReviewsByAReviewer(int reviewerId);
        Task<ReviewerDto> GetReviewerByAReview(int reviewId);
    }
}
