using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(IBookRepository repository,ITicketRepository repository1)
    {
        private readonly IBookRepository _repository = repository;
        private readonly ITicketRepository _repository1 = repository1;

        [HttpGet]
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _repository.GetBooks();
        }
        [HttpPost]
        public async Task<int> CreateBook([FromBody] BookRequest request)
        {
            return await _repository.CreateBooks(request.Title, request.authorId, request.publishDate, request.genreId, request.price);
        }
        [HttpPut("{id}")]
        public async Task<int> UpdateBook(int id, [FromBody] BookRequest request)
        {
            return await _repository.UpdateBook(id, request.Title, request.authorId,request.publishDate,request.genreId, request.price);
        }
        [HttpDelete("{id}")]
        public async Task<int> DeleteBook(int id)
        {
            return await _repository.DeleteBook(id);
        }
        [HttpGet("{name}")]
        [Route("/name")]
        public async Task<Book?> GetBookByName(string name)
        {
            return await _repository.GetBookByName(name);
        }
        [HttpGet("{id:int}")]
        public async Task<List<BookReponse>> GetBookByUsersId(int id)
        {
            var books = await _repository1.GetBooksByUserId(id);
            var response = books.Select(b => new BookReponse(b.Id, b.Title, b.Author.Fio, b.PublishDate, b.Genre.Name, b.Price)).ToList();
            return response;
        }
    }
}
