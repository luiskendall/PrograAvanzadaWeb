using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

namespace FrontEnd.Helpers
{

    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        //Constructor sin Token
        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5214");
            Client.DefaultRequestHeaders.Add("ApiKey", "123");

        }

        //Constructor con Token
        public ServiceRepository(string token)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5214");
            Client.DefaultRequestHeaders.Add("ApiKey", "123");
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
