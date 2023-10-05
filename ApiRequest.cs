using System;
using System.Collections.Generic;
namespace Wheelzy;

public static class ApiRequest
{
    public static async Task<int> MakeApiRequest(string apiUrl, int customerNumber)
    {
        using HttpClient client = new();

        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("customerNumber", customerNumber.ToString())
        });

        var response = await client.PostAsync(apiUrl, content);

        if(response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            if(int.TryParse(responseContent, out int result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException("Invalid API response format.");
            }
        }
        else
        {
            throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
        }
    }

    public static int GenerateNumber()
    {
        // Generate a random 4-digit number (between 1000 and 9999)
        Random random = new ();
        return random.Next(1000, 10000);
    }
}
