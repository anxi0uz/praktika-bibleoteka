using ApiBookStore.Abstractions;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(IBookRepository repository)
    {
        private readonly IBookRepository _repository = repository;

        [HttpGet]
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _repository.GetBooks();
        }

    }
}
