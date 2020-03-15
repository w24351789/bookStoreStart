using BookGUI.Services.ModelDTOs;
using System.Collections.Generic;

namespace BookGUI.ViewModels
{
    public class ReviewerDetailViewModel
    {
        public ReviewerDto Reviewer { get; set; }
        public IDictionary<ReviewDto, BookDto> ReviewAndBook { get; set; }
    }
}
