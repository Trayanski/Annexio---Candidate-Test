'use strict'

const RowHTMLTemplate = "<b>{0}</b>: {1}<br/ ><br/ >";
const DrillDownRowHTMLTemplate = "<br/ ><b> - {0}:</b> {1}";
const ArrayRowHTMLTemplate = "<br/ ><b> - </b> {0}";
const LinkHTMLTemplate = "<a onclick='{0}(\"{1}\")'>{1}</a>";

class CountryViewer {

	constructor(context) {
		var _this = this;

		_this.init(context);
	}

	init(context) {
		var _this = this;
		var $element = $(context.containerId)
		debugger;
	}

	// Country Details
	getCountryDetailsByName(name) {
		var _this = this;

		$.ajax({
			type: "GET",
			url: _this.ajaxUrls.getCountryDetailsByName + "?name=" + name,
			success: function (data) {
				_this.populateWithCountryDetails(data);
			}
		});
	}
	getCountryDetailsByAlpha3Code(alpha3Code) {
		var _this = this;

		$.ajax({
			type: "GET",
			url: _this.ajaxUrls.getCountryDetailsByAlpha3Code + "?alpha3Code=" + alpha3Code,
			success: function (data) {
				_this.populateWithCountryDetails(data);
			}
		});
	}
	populateWithCountryDetails(data) {
		if (!data) {
			return;
		}

		// create container
		var $details = $("<div></div>");
		// add styles
		$details.addClass("show-details-content")
		// details title
		$details.append("<b><h2>Country Details</h2></b>");

		$.each(data, function (index, value) {
			var dataItem = value[0];
			if (dataItem != undefined) {
				$details.append(
					// Name
					RowHTMLTemplate.format("Name", dataItem.Name)
					// Capital
					+ RowHTMLTemplate.format("Capital", dataItem.Capital)
					// Population
					+ RowHTMLTemplate.format("Population", dataItem.Population)
					// Currencies
					+ RowHTMLTemplate.format("Currencies", $.map(dataItem.Currencies, function (e) {
						return DrillDownRowHTMLTemplate.format("Name", e.Name) + ", "
							+ DrillDownRowHTMLTemplate.format("Code", e.Code) + ", "
							+ DrillDownRowHTMLTemplate.format("Symbol", e.Symbol) + ";"

					}).join())
					// Languages
					+ RowHTMLTemplate.format("Languages", $.map(dataItem.Languages, function (e) {
						return DrillDownRowHTMLTemplate.format("Name", e.Name) + ", "
							+ DrillDownRowHTMLTemplate.format("NativeName", e.NativeName) + ", "
							+ DrillDownRowHTMLTemplate.format("Iso639_1", e.NativeName) + ", "
							+ DrillDownRowHTMLTemplate.format("Iso639_2", e.NativeName) + ";"
					}).join())
					// Borders
					+ RowHTMLTemplate.format("Borders", $.map(dataItem.Borders, function (e) {
						return ArrayRowHTMLTemplate.format(LinkHTMLTemplate.format("_this.getCountryDetailsByAlpha3Code", e))
					})));
			}
			else {
				$details.append("Details not Available");
			}
		});

		// visualize details
		$("#show-details")
			.empty()
			.append($details);
	}

	// Region Details
	getRegionDetails(region) {
		var _this = this;

		$.ajax({
			type: "GET",
			url: _this.ajaxUrls.getRegionDetails + "?region=" + region,
			success: function (data) {
				_this.populateWithRegionDetails(data);
			}
		});
	}
	getSubregionDetails(subregion) {
		var _this = this;

		$.ajax({
			type: "GET",
			url: _this.ajaxUrls.getSubregionDetails + "?subregion=" + subregion,
			success: function (data) {
				_this.populateWithRegionDetails(data, true);
			}
		});
	}
	populateWithRegionDetails(data, shouldPreviewSubregionDetails) {
		if (!data) {
			return;
		}

		// create container
		var $details = $("<div></div>");
		// add styles
		$details.addClass("show-details-content")

		var previewRegionType = shouldPreviewSubregionDetails ? "Subregion" : "Region";
		// details title
		$details.append("<b><h2>" + previewRegionType + " Details</h2></b>");


		var dataItem = data.result;

		$details.append(
			// Name
			RowHTMLTemplate.format("{0} Name".format(previewRegionType), dataItem.Name)
			// Population
			+ RowHTMLTemplate.format("Population", dataItem.Population)
			// Region
			+ (shouldPreviewSubregionDetails
				? RowHTMLTemplate.format("Region", LinkHTMLTemplate.format("_this.getRegionDetails", dataItem.Region))
				: "")
			// Countries
			+ RowHTMLTemplate.format("Countries (Under The Region)", $.map(dataItem.Countries, function (e) {
				return ArrayRowHTMLTemplate.format(LinkHTMLTemplate.format("_this.getCountryDetailsByName", e))
			}))
			// Subregions
			+ (!shouldPreviewSubregionDetails
				? RowHTMLTemplate.format("Subregions (Under The Region)", $.map(dataItem.Subregions, function (e) {
					return ArrayRowHTMLTemplate.format(LinkHTMLTemplate.format("_this.getSubregionDetails", e))
				}))
				: ""));

		// visualize details
		$("#show-details")
			.empty()
			.append($details);
	}
}