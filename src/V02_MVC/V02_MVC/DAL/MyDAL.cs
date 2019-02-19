using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.DAL
{
    class MyDAL
    {
        private static MyDAL _instance;
        private HttpClient HttpClient;

        public MyDAL()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:8080/");
        }

        public static MyDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MyDAL();
                }
                return _instance;
            }
        }

        public async Task<string> GetAsync(string Url)
        {
            string JsonString = "";
            HttpResponseMessage Response = HttpClient.GetAsync(Url).Result;
            if (Response.IsSuccessStatusCode)
            {
                JsonString = await Response.Content.ReadAsStringAsync();
            }

            return JsonString;
        }

        public async Task<HttpResponseMessage> PostAsync(string Url, StringContent HttpContent)
        {
            var HttpResponse = await HttpClient.PostAsync(Url, HttpContent);
            return HttpResponse;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string Url)
        {
            var HttpResponse = await HttpClient.DeleteAsync(Url);
            return HttpResponse;
        }

        public async Task<HttpResponseMessage> PutAsync(string Url, StringContent HttpContent)
        {
            var HttpResponse = await HttpClient.PutAsync(Url, HttpContent);
            return HttpResponse;
        }

    }
}
