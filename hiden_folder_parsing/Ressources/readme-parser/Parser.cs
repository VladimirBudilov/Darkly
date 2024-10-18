using HtmlAgilityPack;

namespace readme_parser;

public static class Parser
{
	private static readonly HttpClient HttpClient = new();

	public static async Task ScrapingRecursive(string url)
	{
		try
		{
			var response = await HttpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();

			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(body);

			var links = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
			if (links != null)
			{
				foreach (var link in links)
				{
					var finalLink = link.Attributes["href"].Value;

					if (finalLink == "README")
					{
						var readmeResponse = await HttpClient.GetAsync(url + finalLink);
						var readmeText = await readmeResponse.Content.ReadAsStringAsync();

						if (!readmeText.Contains("flag")) continue;
						Console.WriteLine(readmeText);
						Environment.Exit(0);
					}
					else if (finalLink != "../")
					{
						await ScrapingRecursive(url + finalLink);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
	}
}