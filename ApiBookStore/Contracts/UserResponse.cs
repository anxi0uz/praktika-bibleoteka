namespace ApiBookStore.Contracts
{
    public record UserResponse(
        int id,string fio,string birthDate,string adress,string phoneNumber,int roleId);
}
