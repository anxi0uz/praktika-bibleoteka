﻿using ApiBookStore.Contracts;
using ApiBookStore.Models;
using ApiBookStore.Repositories;

namespace ApiBookStore.Abstractions
{
    public interface IBookRepository
    {
        Task<int> CreateBooks(string title, int authorId, string publishDate, int genreId, decimal price);
        Task<int> DeleteBook(int id);
        Task<List<BookReponse>> GetBooks();
        Task<int> UpdateBook(int id, string title, int authorId, string publishDate, int genreId, decimal price);
        Task<Book?> GetBookByName(string name);
    }
}