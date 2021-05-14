using CandidateTest_BE_TrayanKarastoyanov.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CandidateTest_BE_TrayanKarastoyanov.Controllers
{
    public class DataController : BaseController
    {
		[HttpGet()]
		public ActionResult GetCountryDetailsByName(string name)
		{
			// validation
			if (name == null || name == string.Empty || name.Equals("undefined"))
				return null;

			// get data
			List<CountryModel> result = DataProvider.GetAllCountries().Where(x => x.Name.Equals(name)).ToList();

			// return data as json
			return Json(new { list = result }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet()]
		public ActionResult GetCountryDetailsByAlpha3Code(string alpha3Code)
		{
			// validation
			if (alpha3Code == null || alpha3Code == string.Empty || alpha3Code.Equals("undefined"))
				return null;

			// get data
			List<CountryModel> result = DataProvider.GetAllCountries().Where(x => x.Alpha3Code.Equals(alpha3Code)).ToList();

			// return data as json
			return Json(new { list = result }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet()]
		public ActionResult GetRegionDetails(string region)
		{
			// validation
			if (region == null || region == string.Empty || region.Equals("undefined"))
				return null;

			// get data
			List<CountryModel> countriesUnderTheRegion = DataProvider.GetAllCountries().Where(x => x.Region.Equals(region)).ToList();
			ulong countriesUnderTheRegionPopulation = 0;
			HashSet<string> countriesUnderTheRegionNames = new HashSet<string>();
			HashSet<string> countriesUnderTheRegionSubregions = new HashSet<string>();
			foreach (var country in countriesUnderTheRegion)
			{
				countriesUnderTheRegionPopulation += (ulong)country.Population;
				countriesUnderTheRegionNames.Add(country.Name);
				countriesUnderTheRegionSubregions.Add(country.Subregion);
			}

			RegionDetailsModel result = new RegionDetailsModel()
			{
				Name = region,
				Population = countriesUnderTheRegionPopulation,
				Countries = countriesUnderTheRegionNames.ToArray(),
				Subregions = countriesUnderTheRegionSubregions.ToArray()
			};

			// return data as json
			return Json(new { result }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet()]
		public ActionResult GetSubregionDetails(string subregion)
		{
			// validation
			if (subregion == null || subregion == string.Empty || subregion.Equals("undefined"))
				return null;

			// get data
			List<CountryModel> countriesUnderTheSubregion = DataProvider.GetAllCountries().Where(x => x.Subregion.Equals(subregion)).ToList();
			ulong countriesUnderTheRegionPopulation = 0;
			HashSet<string> countriesUnderTheRegionNames = new HashSet<string>();
			string region = string.Empty;
			foreach (var country in countriesUnderTheSubregion)
			{
				countriesUnderTheRegionPopulation += (ulong)country.Population;
				countriesUnderTheRegionNames.Add(country.Name);
				if (region.Equals(string.Empty))
				{
					region = country.Region;
				}
			}

			SubregionDetailsModel result = new SubregionDetailsModel()
			{
				Name = subregion,
				Population = countriesUnderTheRegionPopulation,
				Region = region,
				Countries = countriesUnderTheRegionNames.ToArray()
			};

			// return data as json
			return Json(new { result }, JsonRequestBehavior.AllowGet);
		}
	}
}