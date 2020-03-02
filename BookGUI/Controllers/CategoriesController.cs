using System.Linq;
using System.Threading.Tasks;
using BookGUI.Services;
using BookGUI.Services.ModelDTOs;
using BookGUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookGUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepositoryGUI _categoryRepositoryGUI;

        public CategoriesController(ICategoryRepositoryGUI categoryRepositoryGUI)
        {
            _categoryRepositoryGUI = categoryRepositoryGUI;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryRepositoryGUI.GetCategories();

            if(categories.Count() <= 0)
            {
                ViewBag.Message = "Categories did not exists in database";
            }
            return View(categories);
        }

        public async Task<ActionResult> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepositoryGUI.GetCategoryById(categoryId);
            
            if(category == null)
            {
                ModelState.AddModelError("", "Error getting a category");
                ViewBag.Message = $"ID {categoryId}'s category did not exist in database";
                category = new CategoryDto();
            }

            var books = await _categoryRepositoryGUI.GetBooksFromACategory(categoryId);

            if(books.Count() <= 0)
            {
                ViewBag.BookMessage = $"{category.Name} did not have any books";
            }

            var bookCategory = new CategoryBooksViewModel
            {
                Category = category,
                Books = books
            };

            return View(bookCategory);
        }
    }
}