using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController(IAuthorRepository repository)
{
    private readonly IAuthorRepository _repository = repository;

    [HttpGet]
    public async Task<List<Author>> GetAuthors()
    {
        return await _repository.GetAuthors();
    }

    [HttpPost]
    public async Task<int> CreateAuthor(AuthorRequest authorRequest)
    {
        return await _repository.CreateAuthor(authorRequest.fio);
    }

    [HttpPut("{id}")]
    public async Task<int> UpdateAuthor(int id, AuthorRequest authorRequest)
    {
        return await _repository.UpdateAuthor(id, authorRequest.fio);
    }

    [HttpDelete("{id}")]
    public async Task<int> DeleteAuthor(int id)
    {
        return await _repository.DeleteAuthor(id);
    }
}