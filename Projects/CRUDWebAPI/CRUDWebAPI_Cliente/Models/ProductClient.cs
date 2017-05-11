using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CRUDWebAPI_Cliente.Models
{
    public class ProductClient
    {
        private string BASE_URL = "http://localhost:55915/api/";

        public object Product { get; internal set; }
        public Func<Product> Getproduct { get; internal set; }

        public IEnumerable<Product> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("product").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                return null;

            }
            catch
            {
                return null;
            }
        }

        internal void Create(object product)
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("products/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Product>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Product product)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("products", product).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        internal void Edit(object product)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Product product)
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("products/" + product.ContatoID, product).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("products/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        

    }
}