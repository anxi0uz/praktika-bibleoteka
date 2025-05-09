﻿using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.DataAccess;
using ApiBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ApiBookStore.Repositories
{
    public class TicketRepository(AppDbContext context) : ITicketRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<List<Ticket>> GetTickets()
        {
            return await _context.Tickets.AsNoTracking().ToListAsync();
        }
        public async Task<int> CreateTicket(int idUser, int idBook, string dateReceived, string datePost, int ticketNumber)
        {
            var ticket = new Ticket() { IdUser = idUser, IdBook = idBook, DateReceived = dateReceived, DatePost = datePost, TickerNumber = ticketNumber };
            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket.Id;
        }
        public async Task<int> UpdateUser(int id, int idUser, int idBook, string dateReceived, string datePost, int ticketNumber)
        {
            await _context.Tickets.Where(t => t.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.IdUser, idUser)
                .SetProperty(p => p.IdBook, idBook)
                .SetProperty(p => p.DateReceived, dateReceived)
                .SetProperty(p => p.DatePost, datePost)
                .SetProperty(p => p.TickerNumber, ticketNumber));
            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<int> DeleteTicket(int id)
        {
            await _context.Tickets.Where(t => t.Id == id).ExecuteDeleteAsync();
            return id;
        }
        public async Task<List<Book>> GetBooksByUserId(int id)
        {
            var tickets = _context.Tickets.Include(p=>p.IdBookNavigation).Where(p=>p.IdUser == id);
            var books = _context.Books.Where(b => tickets.Select(t => t.IdBook).Any(t=> t == b.Id)).Include(s => s.Genre).Include(s => s.Author).ToList();
            //var books = tickets.Select(s => s.IdBookNavigation).Include(s=>s.Genre).Include(s=>s.Author).ToList();

            return books;
        }
        public async Task<List<TicketResponse>> GetTicketsByUser(int id)
        {
            return await _context.Tickets
                .Include(p => p.IdBookNavigation)
                .Where(p => p.IdUser == id)
                .Select(s => new TicketResponse(s.Id, s.IdBookNavigation.Title, s.DateReceived, s.DatePost, s.TickerNumber))
                .ToListAsync();
        }
    }
}
