using BookGUI.Services;
using BookGUI.Services.ModelDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookGUI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepositoryGUI _countryRepository;

        public CountriesController(ICountryRepositoryGUI countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<ActionResult> Index()
        {
            var countries = await _countryRepository.GetCountries();

            if(countries.Count() <= 0)
            {
                ViewBag.Message = "There was a problem retrieving countries from " +
                    "the database or no country exists";
            }

            return View(countries);
        }

        public async Task<ActionResult> GetCountryById(int countryId)
        {
            var country = await _countryRepository.GetCountryById(countryId);
            
            if(country == null)
            {
                ModelState.AddModelError("", "Error getting a country.");
                ViewBag.Message = "There was a problem retrieving the country" +
                    $"the id {countryId} did not exists in database";

                country = new CountryDto();
            }

            return View(country);
        }


    }
}
