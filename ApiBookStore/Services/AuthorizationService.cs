using ApiBookStore.Abstractions;
using ApiBookStore.Models;

namespace ApiBookStore.Services
{
    public class AuthorizationService(IUserRepository repository) : IAuthorizationService
    {
        private readonly IUserRepository _repository = repository;
        public async Task<(bool response,User user)> Authorize(string login, string password)
        {
            var user = await _repository.Authorize(login, password);
            bool response;
            if (user == null)
                response = false;
            else response = true;
            return (response, user);
        }
        public async Task<int> SignUp(string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId)
        {
            return await _repository.CreateUser(login, password, fio, birthdate, adress, phoneNumber, RoleId);
        }
    }
}
