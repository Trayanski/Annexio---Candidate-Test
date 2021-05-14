using System;
using System.Linq.Expressions;

namespace CandidateTest_BE_TrayanKarastoyanov.Models
{
	public class RegionDetailsModel : IBaseRegionDetailsModel
	{
		public string Name { get; set; }
		public ulong? Population { get; set; }
		public string[] Countries { get; set; }
		public string[] Subregions { get; set; }
	}
}
