using System;

namespace CandidateTest_BE_TrayanKarastoyanov.Models
{
	public class LanguageModel : IBaseModel
	{
		public string Name { get; set; }
		public string NativeName { get; set; }
		public string Iso639_1 { get; set; }
		public string Iso639_2 { get; set; }
	}
}
