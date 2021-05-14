// String Extensions
String.format = function (pattern, args) {
	var _args = arguments;
	return pattern.replace(/(?<!\{)\{(\d+):?(.*?)\}(?!\})/g, function (capture, index, format) {
		var idx = parseInt(index, 10);
		var value = _args[idx + 1];
		if (value === null || value === undefined) {
			return "";
		}
		return value;
	});
};
String.prototype.format = function (args) {
	// convert the arguments to an array
	var _args = Array.prototype.slice.call(arguments);
	// insert the format pattern as first argument
	_args.splice(0, 0, this.toString());
	// call the static format method and pass the arguments
	return this.constructor.format.apply(null, _args);
};