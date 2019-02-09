﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class RestModel
    {
        private static RestModel _instance;

        private List<WorkerDto> Workers;

        private List<CarDto> Cars;

        private HttpClient Client;

        public RestModel() {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
        }

        public static RestModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RestModel();
                }
                return _instance;
            }
        }
        private async Task fetchWorkers()
        {
            HttpResponseMessage Response = Client.GetAsync("2019_02_06_MVC_Backend/rest/workers").Result;
            if (Response.IsSuccessStatusCode)
            {

                // Get the response
                var customerJsonString = await Response.Content.ReadAsStringAsync();

                // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<WorkerDto>>(custome‌​rJsonString);
                // Do something with it

                Workers = deserialized.ToList<WorkerDto>();
            }
        }

        private async Task fetchCars()
        {
            HttpResponseMessage Response = Client.GetAsync("2019_02_06_MVC_Backend/rest/cars").Result;  
            if (Response.IsSuccessStatusCode)
            {
                // Get the response
                var customerJsonString = await Response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<CarDto>>(custome‌​rJsonString);
                // Do something with it

                Cars = deserialized.ToList<CarDto>();
            }
        }



        public async Task<List<WorkerDto>> GetWorkers()
        {
            if(Workers == null)
            {
                await fetchWorkers();
            }
            
            return Workers;
        }

        public async Task<List<CarDto>> GetCars()
        {
            if (Cars == null)
            {
                await fetchCars();
            }

            return Cars;
        }
    }
}