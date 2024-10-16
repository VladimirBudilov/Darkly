namespace exploinator;

public static class Validator
{
	public static void ValidateArgs(string[] args)
	{
		if (args.Length == 1) return;
		Console.Error.WriteLine("Please provide only an IP address as a parameter.");
		Environment.Exit(1);
	}

	public static void ValidateIpAddress(string ipAddress)
	{
		if (!string.IsNullOrEmpty(ipAddress)) return;
		Console.Error.WriteLine("Please provide only an IP address as a parameter.");
		Environment.Exit(1);
	}
}