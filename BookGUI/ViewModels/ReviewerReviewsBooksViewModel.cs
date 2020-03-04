using BookGUI.Services.ModelDTOs;
using System.Collections.Generic;

namespace BookGUI.ViewModels
{
    public class ReviewerReviewsBooksViewModel
    {
        public ReviewerDto  Reviewer { get; set; }
        public IDictionary<ReviewDto, BookDto> ReviewAndBook { get; set; }
    }
}
