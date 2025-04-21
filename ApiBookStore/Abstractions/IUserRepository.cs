using ApiBookStore.Models;

namespace ApiBookStore.Abstractions
{
    public interface IUserRepository
    {
        Task<User?> Authorize(string login, string password);
        Task<int> CreateUser(string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId);
        Task<int> DeleteUser(int id);
        Task<List<User>> GetUsersAsync();
        Task<int> UpdateUser(int id, string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId);
    }
}