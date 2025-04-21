using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserRepository repository, IAuthorizationService authorizationService)
    {
        private readonly IUserRepository _repository = repository;
        private readonly IAuthorizationService _authorizationService = authorizationService;

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

        [HttpGet("authorize")]
        public async Task<User> AuthorizeUser([FromBody] UserAuthorizeRequest request)
        {
            var response = await _authorizationService.Authorize(request.login, request.password);
            if (response.response == false) return null;
            else return response.user;
        }

        [HttpPost("authorize")]
        public async Task<int> RegisterUser([FromBody] UserRequest request)
        {
            return await _authorizationService.SignUp(request.login, request.password, request.fio, request.birthday, request.adress, request.phone, request.role);
        }
    }

}
