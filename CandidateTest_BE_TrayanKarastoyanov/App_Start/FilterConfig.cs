using System.Web;
using System.Web.Mvc;

namespace CandidateTest_BE_TrayanKarastoyanov
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
