using BookGUI.Infrastructure;
using BookGUI.Services.ModelDTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public class CategoryRepositoryGUI : ICategoryRepositoryGUI
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;

        public CategoryRepositoryGUI(HttpClient client)
        {
            _client = client;
            _baseUri = "http://localhost:5000/api";
        }

        public async Task<IEnumerable<BookDto>> GetBooksFromACategory(int categoryId)
        {
            IEnumerable<BookDto> books = new List<BookDto>();

            var uri = API.Category.GetBooksFromACategory(_baseUri, categoryId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<IEnumerable<BookDto>>(content);
            }

            return books;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            IEnumerable<CategoryDto> categories = new List<CategoryDto>();

            var uri = API.Category.GetCategories(_baseUri);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(content);
            }

            return categories;
        }

        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            CategoryDto category = new CategoryDto();

            var uri = API.Category.GetCategoryById(_baseUri, categoryId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                category = JsonConvert.DeserializeObject<CategoryDto>(content);
            }

            return category;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesOfABook(int bookId)
        {
            IEnumerable<CategoryDto> categories = new List<CategoryDto>();

            var uri = API.Category.GetCategoryOfABook(_baseUri, bookId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(content);
            }

            return categories;
        }
    }
}
