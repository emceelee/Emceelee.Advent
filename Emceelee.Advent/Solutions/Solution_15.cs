using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Emceelee.Advent.Solutions
{
    public class Solution_15 : ISolution
    {
        public void Solve()
        {
            try
            {
                for(int i = 80000; i <= 99999; ++i)
                {
                    if(i.ToString().Select(k => int.Parse(k.ToString())).Sum() == 12)
                    {
                        var result = UnlockSafeAsync(i.ToString()).Result;

                        if(result.success)
                        {
                            Console.WriteLine($"Day 15 Solution: Code: {i}, message: {result.secret_message}");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task<SafeUnlockResponse> UnlockSafeAsync(string code)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://safe.adventofquorum.org/docs");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new SafeUnlockRequest() { code = code };
            var json = JsonConvert.SerializeObject(request);

            var httpResponse = await client.PostAsync("safe/unlock", new StringContent(json, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsAsync<SafeUnlockResponse>();

            return response;
        }
    }

    public class SafeUnlockRequest
    {
        public string code { get; set; }
    }

    public class SafeUnlockResponse
    {
        public bool success { get; set; }
        public string secret_message { get; set; }
    }
}
