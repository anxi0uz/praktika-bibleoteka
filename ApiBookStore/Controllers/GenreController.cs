using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController(IGenreRepository repository)
{
    private readonly IGenreRepository _repository = repository;

    [HttpGet]
    public async Task<List<Genre>> GetAllGenres()
    {
        return await _repository.GetGenres();
    }

    [HttpPost]
    public async Task<int> CreateGenre([FromBody]GenreRequest genreRequest)
    {
        return await _repository.CreateGenre(genreRequest.Name);
    }

    [HttpPut("{id}")]
    public async Task<int> UpdateGenre(int id, [FromBody] GenreRequest genreRequest)
    {
        return await _repository.UpdateGenre(id, genreRequest.Name);
    }

    [HttpDelete("{id}")]
    public async Task<int> DeleteGenre(int id)
    {
        return await _repository.DeleteGenre(id);
    }
}