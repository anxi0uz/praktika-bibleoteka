using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;
        [HttpGet]
        public async Task<List<User>> GetUsersAsync()=>await _repository.GetUsersAsync();
        [HttpPost]
        public async Task<int> CreateUser([FromBody] UserRequest request)
        {
            return await _repository.CreateUser(request.login, request.password, request.fio, request.birthday, request.adress, request.phone, request.role);
        }
        [HttpPut("{id}")]
        public async Task<int> UpdateUser(int id, [FromBody] UserRequest request) => await _repository.UpdateUser(id, request.login, request.password, request.fio, request.birthday, request.adress ,request.phone, request.role);
        [HttpDelete("{id}")]
        public async Task<int> DeleteUser(int id)
        {
            return await _repository.DeleteUser(id);
        }
    }

}
