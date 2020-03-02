using BookGUI.Services.ModelDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public interface ICategoryRepositoryGUI
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategoryById(int categoryId);
        Task<IEnumerable<BookDto>> GetBooksFromACategory(int categoryId);
        Task<IEnumerable<CategoryDto>> GetCategoriesOfABook(int bookId);
    }
}
