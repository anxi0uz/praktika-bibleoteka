using ApiBookStore.Abstractions;
using ApiBookStore.DataAccess;
using ApiBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBookStore.Repositories
{
    public class AuthorRepository(AppDbContext context) : IAuthorRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Author>> GetAuthors() => await _context.Authors.AsNoTracking().ToListAsync();

        public async Task<int> CreateAuthor(string fio, int bookId)
        {
            var author = new Author { IdBook = bookId, Fio = fio };
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }
        public async Task<int> UpdateAuthor(int id, string fio, int bookId)
        {
            await _context.Authors.Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.Fio, fio)
                .SetProperty(u => u.IdBook, bookId));
            return id;
        }
        public async Task<int> DeleteAuthor(int id)
        {
            await _context.Authors.Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
