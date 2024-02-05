using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WSSeriesMvvm.Models;

namespace WSSeriesMvvm.Services
{
    public class WSService : IService
    {
        private HttpClient client;


        public WSService(string uri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Serie>> GetSeriesAsync()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(client.BaseAddress);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Serie>(String.Concat(client.BaseAddress, "/", id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(Serie serie)
        {
            try
            {
                var response = await client.PostAsJsonAsync<Serie>(client.BaseAddress, serie);
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PutSerieAsync(int id, Serie serie)
        {
            try
            {
                using var response = await client.PutAsJsonAsync<Serie>(String.Concat(client.BaseAddress, "/", id), serie);
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSerieAsync(int id)
        {
            try
            {
                using var response = await client.DeleteAsync(String.Concat(client.BaseAddress, "/", id));
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
