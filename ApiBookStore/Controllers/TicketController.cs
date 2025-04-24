using ApiBookStore.Abstractions;
using ApiBookStore.Contracts;
using ApiBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBookStore.Controllers;
[ApiController]
[Route("[controller]")]
public class TicketController(ITicketRepository repository)
{
    private readonly ITicketRepository _repository = repository;

    [HttpGet]
    public async Task<List<TicketResponse2>> GetAllTickets()
    {
        var tickets = await _repository.GetTickets();
        var response = tickets.Select(s => new TicketResponse2(s.Id, s.IdUser, s.IdBook, s.DateReceived, s.DatePost, s.TickerNumber)).ToList();
        return response;
    }

    [HttpPost]
    public async Task<int> CreateTicket([FromBody] TicketRequest request)
    {
        return await _repository.CreateTicket(request.idUser,request.idBook,request.dateReceived,request.datePost,request.ticketТumber);
    }

    [HttpPut("{id}")]
    public async Task<int> UpdateTicket(int id, [FromBody] TicketRequest request)
    {
        return await _repository.UpdateUser(id,request.idUser,request.idBook,request.dateReceived,request.datePost,request.ticketТumber);
    }

    [HttpDelete("{id}")]
    public async Task<int> DeleteTicket(int id)
    {
        return await _repository.DeleteTicket(id);
    }
    [HttpGet("{id:int}")]
    public async Task<List<TicketResponse>> GetTicketsByUser(int id)
    {
        return await _repository.GetTicketsByUser(id);
    }
}