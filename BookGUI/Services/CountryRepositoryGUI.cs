using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookGUI.Infrastructure;
using BookGUI.Services.ModelDTOs;
using Newtonsoft.Json;

namespace BookGUI.Services
{
    public class CountryRepositoryGUI : ICountryRepositoryGUI
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;

        public CountryRepositoryGUI(HttpClient client)
        {
            _client = client;
            _baseUri = "http://localhost:5000/api";
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsFromACountry(int countryId)
        {
            IEnumerable<AuthorDto> authors = new List<AuthorDto>();

            var uri = API.Country.GetAuthorsFromCountry(_baseUri, countryId);

            var reponse = await _client.GetAsync(uri);

            if (reponse.IsSuccessStatusCode)
            {
                var content = await reponse.Content.ReadAsStringAsync();

                authors = JsonConvert.DeserializeObject<IEnumerable<AuthorDto>>(content);
            }

            return authors;
        }

        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            IEnumerable<CountryDto> countries = new List<CountryDto>();
            
            var uri = API.Country.GetCountries(_baseUri);

            var response = await _client.GetAsync(uri);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                countries = JsonConvert.DeserializeObject<IEnumerable<CountryDto>>(content);
            }

            

            return countries;

        }
        public async Task<CountryDto> GetCountryById(int countryId)
        {
            CountryDto country = new CountryDto();

            var uri = API.Country.GetCountryById(_baseUri, countryId);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                country = JsonConvert.DeserializeObject<CountryDto>(content);
            }

            return country;
        }

        public async Task<CountryDto> GetCountryOfAnAuthor(int authorId)
        {
            CountryDto country = new CountryDto();

            var uri = API.Country.GetCountryFromAnAuthor(_baseUri, authorId);

            var reponse = await _client.GetAsync(uri);

            if (reponse.IsSuccessStatusCode)
            {
                var content = await reponse.Content.ReadAsStringAsync();

                country = JsonConvert.DeserializeObject<CountryDto>(content);
            }

            return country;
        }
    }
}
