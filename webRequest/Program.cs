using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace webRequest
{
    class Program
    {
        static int seconds = 0;
        static int number = 0;
        
        static async Task Main(string[] args)
        {
            //Timer
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            var httpClient = new HttpClient();

            var url = "https://localhost:44344/home/testsamenode"; //172.29.213.18:32001/home/testanothernode                                                     

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {               
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();

                Console.WriteLine("\n" + "[" + seconds + "sec]" +"Response: " + data);
                aTimer.Enabled = false;
            }                                     
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            seconds++;
            number++;

            //Return time in 24h format 
            var time24 = DateTime.Now.ToString("HH:mm:ss");                     
            DateTime now = DateTime.Now;

            string strDate = now.ToString("yyyy-MM-dd"); //Return current date in yyyy-MM-dd format

            Console.WriteLine("| "+ number + "sec |" + " " + time24 + " | " + strDate + " |");                     
            string blank = "--------------------------------";           
            if (seconds >= 10)
            {
                blank = "---------------------------------";
            }
            Console.WriteLine(blank);                    
        }
    }
}
