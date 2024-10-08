﻿using Entities;
using System;
using System.Linq.Expressions;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used as return type for most of countryServices  methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

       
    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse()
            {
                CountryName = country.CountryName,
                CountryID = country.CountryID,
            };
        }
    }
}
