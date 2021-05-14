using CandidateTest_BE_TrayanKarastoyanov.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;

namespace CandidateTest_BE_TrayanKarastoyanov.Helpers
{
	public class DataProvider
	{
		private List<CountryModel> Countries { get; set; }

		public DataProvider()
		{
			// get & store the data
			using (var w = new WebClient())
			{
				var json_data = string.Empty;
				// attempt to download JSON data as a string
				try
				{
					json_data = w.DownloadString("https://restcountries.eu/rest/v2/all");
				}
				catch (Exception) { }
				// if string with JSON data is not empty, deserialize it to class and get its instance 
				Countries = !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<CountryModel>>(json_data) : new List<CountryModel>();
			}
		}

		public List<CountryModel> GetAllCountries()
		{
			return this.Countries;
		}

		public List<CountryModel> GetCountriesFromSearch(string search)
		{
			// get data
			List<CountryModel> result = GetAllCountries()
				.Where(x => x.Name.ToLower().Contains(search.ToLower())
					//|| x.Alpha3Code.ToLower().Contains(search.ToLower())
					|| x.Region.ToLower().Contains(search.ToLower())
					|| x.Subregion.ToLower().Contains(search.ToLower())
				).ToList();

			// return data
			return result;
		}
	}
}