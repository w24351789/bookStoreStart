using BookGUI.Services.ModelDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookGUI.Services
{
    public interface ICountryRepositoryGUI
    {
        Task<IEnumerable<CountryDto>> GetCountries();
        Task<CountryDto> GetCountryById(int countryId);
        Task<CountryDto> GetCountryOfAnAuthor(int authorId);
        Task<IEnumerable<AuthorDto>> GetAuthorsFromACountry(int countryId);
    }
}
