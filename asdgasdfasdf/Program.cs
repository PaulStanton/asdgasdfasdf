using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using asdgasdfasdf.Models;
using Newtonsoft.Json;


namespace asdgasdfasdf
{
    class Program
    {
      
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            List<UserGradebook> grades = new List<UserGradebook>();
            client.BaseAddress = new Uri("http://ec2-54-215-138-178.us-west-1.compute.amazonaws.com/UserBuffetService/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Users/GetAllUserGradebooks").Result;
            if (response.IsSuccessStatusCode)
            {
                var obj = response.Content.ReadAsStringAsync().Result;
                grades = JsonConvert.DeserializeObject<List<UserGradebook>>(obj);
            }

            foreach (var user in grades)
            {
                foreach(var gradebook in user.gradebook)
                {
                    Console.WriteLine($"{user.user.fname} {user.user.lname} {user.Batches[user.gradebook.IndexOf(gradebook)]} {gradebook.ExamSetting.ExamSettingsID} {gradebook.Score}");
                }
            }
            Console.ReadLine();
        }

    }
}
