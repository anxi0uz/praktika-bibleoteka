using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.DataAccess;
using ApiBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBookStore.Repositories
{
    public class BookRepository(AppDbContext context) : IBookRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<BookReponse>> GetBooks()
        {
            var books = await _context.Books.Include(p=>p.Genre).Include(p=>p.Author).AsNoTracking().ToListAsync();
            var response = books.Select(s => new BookReponse(s.Id, s.Title, s.Author.Fio, s.PublishDate, s.Genre.Name, s.Price)).ToList();
            return response;
        }

        public async Task<int> CreateBooks(string title, int authorId, string publishDate, int genreId, decimal price)
        {
            var book = new Book { Title = title, AuthorId = authorId, PublishDate = publishDate, GenreId = genreId, Price = price };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> UpdateBook(int id, string title, int authorId, string publishDate, int genreId, decimal price)
        {
            await _context.Books.Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.Title, title)
                .SetProperty(p => p.AuthorId, authorId)
                .SetProperty(p => p.PublishDate, publishDate)
                .SetProperty(p => p.GenreId, genreId)
                .SetProperty(p => p.Price, price));
            return id;
        }
        public async Task<int> DeleteBook(int id)
        {
            await _context.Books.Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
        public async Task<Book?> GetBookByName(string name)
        {
            return await _context.Books
                 .Where(p => p.Title.ToLower().Replace(" ", "") == name.ToLower().Replace(" ", "")).FirstOrDefaultAsync();
        }

    }
}
