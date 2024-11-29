using System.Text;
using Test.Utility;

namespace Test.Network
{
    internal class HttpCore : Singleton<HttpCore>
    {
        static readonly HttpClient __httpClient = new HttpClient();

        public async Task GetAsync(string url)
        {
            try
            {
                using(var response = await __httpClient.GetAsync(url))
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

        public async Task PostAsync(string url, string serializeData)
        {
            try
            {
                StringContent jsonContent = new StringContent(serializeData, Encoding.UTF8, "application/json");

                using (var response = await __httpClient.PostAsync(url, jsonContent))
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
