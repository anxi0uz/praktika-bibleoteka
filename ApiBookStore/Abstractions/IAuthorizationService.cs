namespace ApiBookStore.Abstractions
{
    public interface IAuthorizationService
    {
        Task<bool> Authorize(string login, string password);
        Task<int> SignUp(string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId);
    }
}