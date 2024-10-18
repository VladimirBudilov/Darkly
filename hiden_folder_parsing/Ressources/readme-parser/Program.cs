using readme_parser;


if (!Validator.ValidateArguments(args))
{
	Environment.Exit(1);
}

var ipAddress = args[0];
var baseUrl = $"http://{ipAddress}/.hidden/";

Parser.ScrapingRecursive(baseUrl).GetAwaiter().GetResult();