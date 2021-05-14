using CandidateTest_BE_TrayanKarastoyanov.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTest_BE_TrayanKarastoyanov.Controllers
{
    public class BaseController : Controller
    {
        public virtual DataProvider DataProvider { get { return _DataProvider = _DataProvider ?? new DataProvider(); } }

        protected DataProvider _DataProvider;
	}
}