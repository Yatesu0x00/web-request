using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace webRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            
            //var url = "http://localhost:51614/Home/ItWorks";
            var url = "http://localhost:51614/home/test3";
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();
                Console.WriteLine(data);
            }
        }
    }
}
