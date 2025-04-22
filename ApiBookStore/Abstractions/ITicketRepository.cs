using ApiBookStore.Contracts;
using ApiBookStore.Models;

namespace ApiBookStore.Abstractions
{
    public interface ITicketRepository
    {
        Task<int> CreateTicket(int idUser, int idBook, string dateReceived, string datePost, int ticketNumber);
        Task<int> DeleteTicket(int id);
        Task<List<Ticket>> GetTickets();
        Task<int> UpdateUser(int id, int idUser, int idBook, string dateReceived, string datePost, int ticketNumber);
        Task<List<Book>> GetBooksByUserId(int id);
        Task<List<TicketResponse>> GetTicketsByUser(int id);
    }
}