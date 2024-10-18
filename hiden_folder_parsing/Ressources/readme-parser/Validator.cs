namespace readme_parser;

public static class Validator
{
	public static bool ValidateArguments(string[] args)
	{
		if (args.Length != 1)
		{
			Console.WriteLine("Usage: dotnet run <ip_address>");
			return false;
		}

		if (ValidateIpAddress(args[0])) return true;
		Console.WriteLine("Invalid IP address");
		return false;
	}

	private static bool ValidateIpAddress(string ipAddress)
	{
		return Uri.CheckHostName(ipAddress) != UriHostNameType.Unknown;
	}
}