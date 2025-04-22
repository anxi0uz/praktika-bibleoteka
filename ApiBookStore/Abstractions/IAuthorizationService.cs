using ApiBookStore.Models;

namespace ApiBookStore.Abstractions
{
    public interface IAuthorizationService
    {
        Task<(bool response ,User user)> Authorize(string login, string password);
        Task<int> SignUp(string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId);
    }
}