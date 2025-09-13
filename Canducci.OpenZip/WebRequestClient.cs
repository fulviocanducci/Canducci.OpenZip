using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace Canducci.OpenZip
{
    public class WebRequestClient : IWebRequestClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public WebRequestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<ZipCodeResult> GetZipCodeAsync(string zipCode)
        {
            try
            {
                HttpResponseMessage message = await _httpClient.GetAsync(zipCode.ToNumber());                
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    ZipCodeData data = JsonSerializer.Deserialize<ZipCodeData>(json, Options);
                    return ZipCodeResult.Success((int)message.StatusCode, data, message.ReasonPhrase);
                }
                return ZipCodeResult.Fail((int)message.StatusCode, message.ReasonPhrase);
            }
            catch (HttpRequestException ex)
            {
                return ZipCodeResult.Fail(503, ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                return ZipCodeResult.Fail(408, ex.Message);
            }
            catch (Exception ex)
            {
                return ZipCodeResult.Fail(500, ex.Message);
            }
        }
    }
}