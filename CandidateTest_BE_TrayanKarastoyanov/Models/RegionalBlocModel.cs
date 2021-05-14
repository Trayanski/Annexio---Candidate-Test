using System;

namespace CandidateTest_BE_TrayanKarastoyanov.Models
{
	public class RegionalBlocModel : IBaseModel
	{
		public string Name { get; set; }
		public string Acronym { get; set; }
		public string[] OtherAcronyms { get; set; }
		public string[] OtherNames { get; set; }
	}
}
