using ApiBookStore.Abstractions;

namespace ApiBookStore.Services
{
    public class AuthorizationService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;
        public async Task<bool> Authorize(string login, string password)
        {
            var user = await _repository.Authorize(login, password);
            if (user == null)
                return false;
            else return true;
        }
        public async Task<int> SignUp(string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId)
        {
            return await _repository.CreateUser(login,password,fio,birthdate,adress,phoneNumber,RoleId);
        }
    }
}
