using System;
using System.Linq.Expressions;

namespace CandidateTest_BE_TrayanKarastoyanov.Models
{
	public class CountryModel : IBaseModel
	{
		public string Name { get; set; }
		public string[] TopLevelDomain { get; set; }
		public string Alpha2Code { get; set; }
		public string Alpha3Code { get; set; }
		public string[] CallingCodes { get; set; }
		public string Capital { get; set; }
		public string[] AltSpellings { get; set; }
		public string Region { get; set; }
		public string Subregion { get; set; }
		public long? Population { get; set; }
		public float?[] Latlng { get; set; }
		public string Demonym { get; set; }
		public float? Area { get; set; }
		public float? Gini { get; set; }
		public string[] Timezones { get; set; }
		public string[] Borders { get; set; }
		public string NativeName { get; set; }
		public string NumericCode { get; set; }
		public CurrencyModel[] Currencies { get; set; }
		public LanguageModel[] Languages { get; set; }
		public TranslationModel Translations { get; set; }
		public string Flag { get; set; }
		public RegionalBlocModel[] RegionalBlocs { get; set; }
		public string Cioc { get; set; }

		//public string GetPropertyName<T>(Expression<Func<T>> expression) => ((MemberExpression)expression.Body).Member.Name;
	}
}
