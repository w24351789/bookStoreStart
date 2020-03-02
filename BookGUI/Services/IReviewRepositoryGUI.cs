using BookGUI.Services.ModelDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public interface IReviewRepositoryGUI
    {
        Task<IEnumerable<ReviewDto>> GetReviews();
        Task<ReviewDto> GetReviewById(int reviewId);
        Task<IEnumerable<ReviewDto>> GetReviewsForABook(int bookId);
        Task<BookDto> GetBookForAReview(int reviewId);
    }
}
