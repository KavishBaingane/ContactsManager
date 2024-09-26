using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Net.Http.Headers;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries;

        public CountriesService()
        {
            _countries = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //Validation : COuntryAddReq para can'nt be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation : CountryName is null , we have to give exception 
            if(countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: Duplicate country name is not allowed 
            if(_countries.Where(x=>x.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name is already exist");
            }

            //Convert object from country add request to country type
            Country country =  countryAddRequest.ToCountry();

            //geneate countryID
            country.CountryID = Guid.NewGuid();
            _countries.Add(country);
            return country.ToCountryResponse();
        }
    }
}
