using ApiBookStore.Models;

namespace ApiBookStore.Abstractions
{
    public interface IGenreRepository
    {
        Task<int> CreateGenre(string name);
        Task<int> DeleteGenre(int id);
        Task<List<Genre>> GetGenres();
        Task<int> UpdateGenre(int id, string name);
    }
}