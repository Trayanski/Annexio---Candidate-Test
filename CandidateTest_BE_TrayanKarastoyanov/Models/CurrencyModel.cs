using System;

namespace CandidateTest_BE_TrayanKarastoyanov.Models
{
	public class CurrencyModel : IBaseModel
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public string Symbol { get; set; }
	}
}
