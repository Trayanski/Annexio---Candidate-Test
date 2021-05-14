using System;
using System.Linq.Expressions;

namespace CandidateTest_BE_TrayanKarastoyanov.Models
{
	public interface IBaseRegionDetailsModel : IBaseModel
	{
		ulong? Population { get; set; }
		string[] Countries { get; set; }
	}
}
