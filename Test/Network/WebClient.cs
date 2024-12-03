using Newtonsoft.Json;
using System.Text;
using Test.Utility;
using WebPacketLib;

namespace Test.Network
{
    internal class WebClient : Singleton<WebClient>
    {
        readonly HttpClient __httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7234"),
            Timeout = TimeSpan.FromMilliseconds(1 * 30 * 1000)
        };

        public async Task GetAsync(string api)
        {
            try
            {
                using(HttpResponseMessage response = await __httpClient.GetAsync($"{__httpClient.BaseAddress}{api}"))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[HttpCore::Get] Exception! Message:{e.Message}, StackTrace:{e.StackTrace}");
            }
        }

        public async Task PostAsync(string api, MyWebRequest request)
        {
            try
            {
                StringContent jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await __httpClient.PostAsync($"{__httpClient.BaseAddress}{api}", jsonContent))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[HttpCore::Post] Exception! Message:{e.Message}, StackTrace:{e.StackTrace}");
            }
        }
    }
}
