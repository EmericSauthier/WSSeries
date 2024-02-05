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



        public async Task<List<Serie>> GetSeriesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(string nomControleur, int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Serie>(String.Concat(nomControleur, "/", id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> PostSerieAsync(string nomControleur, Serie serie)
        {
            try
            {
                using var response = await client.PostAsJsonAsync<Serie>(nomControleur, serie);
                return response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> PutSerieAsync(string nomControleur, int id, Serie serie)
        {
            try
            {
                using var response = await client.PutAsJsonAsync<Serie>(String.Concat(nomControleur, "/", id), serie);
                return response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> DeleteSerieAsync(string nomControleur, int id)
        {
            try
            {
                using var response = await client.DeleteAsync(String.Concat(nomControleur, "/", id));
                return response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
