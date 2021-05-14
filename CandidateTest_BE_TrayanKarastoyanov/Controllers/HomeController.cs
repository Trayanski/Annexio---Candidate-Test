using CandidateTest_BE_TrayanKarastoyanov.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CandidateTest_BE_TrayanKarastoyanov.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult CountryViewer(string search = "")
		{
			ViewBag.Search = search;
			var data = DataProvider.GetCountriesFromSearch(search);
			return View(data);
		}
	}
}