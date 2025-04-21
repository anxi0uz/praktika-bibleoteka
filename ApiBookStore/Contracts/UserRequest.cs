namespace ApiBookStore.Contracts
{
    public record UserRequest(string login, string password, int role, string fio, string birthday,string adress, string phone);
}
