namespace ApiBookStore.Contracts;

public record TicketRequest(
    int idUser,int idBook,string dateReceived,string datePost,int ticketТumber);