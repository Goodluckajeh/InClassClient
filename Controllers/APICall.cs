using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class APICallController : ControllerBase
{
    private static readonly HttpClient _httpClient = new HttpClient();

    // Asynchronous method to call the Joke API and return the raw JSON response as a string
    [HttpGet("joke")]
    public async Task<IActionResult> GetJokeApiDataAsync()
    {
        var url = "https://v2.jokeapi.dev/joke/Any";
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string data = await response.Content.ReadAsStringAsync();
        return Content(data, "application/json");
    }
}