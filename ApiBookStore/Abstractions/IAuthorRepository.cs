using ApiBookStore.Models;

namespace ApiBookStore.Abstractions
{
    public interface IAuthorRepository
    {
        Task<int> CreateAuthor(string fio);
        Task<int> DeleteAuthor(int id);
        Task<List<Author>> GetAuthors();
        Task<int> UpdateAuthor(int id, string fio);
    }
}