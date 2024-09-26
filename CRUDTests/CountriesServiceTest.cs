using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;

namespace CRUDTests
{
    
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
       
        public CountriesServiceTest(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        //when u supply null , is should aegumentnullexception
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request = null;
            //Assert 
            Assert.Throws<ArgumentNullException>(() => {
                _countriesService.AddCountry(request);
            });
            //Act 
            _countriesService.AddCountry(request);

        }

        //when the countryname is null , it should throuw argumentexception 
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = null,
            };
            //Assert 
            Assert.Throws<ArgumentNullException>(() => {
                _countriesService.AddCountry(request);
            });
            //Act 
            _countriesService.AddCountry(request);

        }

        //when the countryname is duplicate , it should throuw argument 
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new CountryAddRequest()
            {
                CountryName = "USA",
            };
            CountryAddRequest? request2 = new CountryAddRequest()
            {
                CountryName = "USA",
            };
            //Assert 
            Assert.Throws<ArgumentNullException>(() => {
                //Act 
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
            

        }

        //when u supply the proper country name it shoulfd insert the country 
        //to the existing list  ArgumentOutOfRangeException users 

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest()
            {
                CountryName = "Japan",
            };
            //Act 
            CountryResponse response =  _countriesService.AddCountry(request);

            //Assert
            Assert.True(response.CountryID!=Guid.Empty);

        }
    }
}
