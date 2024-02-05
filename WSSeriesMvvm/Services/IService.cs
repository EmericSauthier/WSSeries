using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WSSeriesMvvm.Models;

namespace WSSeriesMvvm.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSeriesAsync();
        Task<Serie> GetSerieAsync(int id);
        Task<bool> PostSerieAsync(Serie serie);
        Task<bool> PutSerieAsync(int id, Serie serie);
        Task<bool> DeleteSerieAsync(int id);
    }
}