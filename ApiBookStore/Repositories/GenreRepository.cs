using ApiBookStore.Abstractions;
using ApiBookStore.DataAccess;
using ApiBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBookStore.Repositories
{
    public class GenreRepository(AppDbContext context) : IGenreRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Genre>> GetGenres()
        {
            return await _context.Genres
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<int> CreateGenre(string name)
        {
            var genre = new Genre { Name = name };
            await _context.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre.Id;
        }
        public async Task<int> UpdateGenre(int id, string name)
        {
            await _context.Genres.Where(g => g.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.Name, name));
            return id;
        }
        public async Task<int> DeleteGenre(int id)
        {
            await _context.Genres.Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
