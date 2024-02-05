using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WSSeriesMvvm.Models;

namespace WSSeriesMvvm.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSeriesAsync(string nomControleur);
        Task<Serie> GetSerieAsync(int id);
        Task<HttpResponseMessage> PutSerieAsync(int id, Serie serie);
        Task<HttpResponseMessage> PostSerieAsync(Serie serie);
        Task<HttpResponseMessage> DeleteSerieAsync();
    }
}