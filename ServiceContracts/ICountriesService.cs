using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logics for manipulating country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>Returns the country object after adding it(Including newaly generated 
        ///Country id)
        ///</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
        
    }
}
