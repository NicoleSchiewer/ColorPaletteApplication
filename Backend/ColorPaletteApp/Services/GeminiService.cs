using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using ColorPaletteApp.Interfaces;
using ColorPaletteApp.Models;

namespace ColorPaletteApp.Services;

public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private const string API_ENDPOINT = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent";

    public GeminiService(IConfiguration config, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiKey = config["Gemini_Apikey"] ?? throw new ArgumentNullException("Gemini_Apikey", "API key cannot be null.");
    }

    public async Task<PaletteResponse> GeneratePaletteAsync(string promptText)
    {
        var fullPrompt = $"Generate a color palette based on this description: \"{promptText}\". Return just a list of 5 hex color codes in JSON array format.";

        var request = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = fullPrompt }
                    }
                }
            },
            generationConfig = new
            {
                temperature = 0.7,
                maxOutputTokens = 256,
                topK = 40,
                topP = 0.95
            }
        };

        var requestJson = JsonSerializer.Serialize(request);
        var httpRequest = new HttpRequestMessage(
            HttpMethod.Post,
            $"{API_ENDPOINT}?key={_apiKey}")
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        };

        var response = await _httpClient.SendAsync(httpRequest);
        var responseJson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Gemini API error: {response.StatusCode}, {responseJson}");
        }

        // Parse response
        var json = JsonDocument.Parse(responseJson);
        var output = json.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        if (string.IsNullOrWhiteSpace(output))
            throw new Exception("Gemini returned an empty response.");

        // Extract hex codes using regex
        var hexMatches = Regex.Matches(output, @"#(?:[0-9a-fA-F]{3}){1,2}")
            .Select(m => m.Value)
            .Distinct()
            .ToList();

        return new PaletteResponse { Colors = hexMatches };
    }
}
