using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public record TicketPost(int idUser, int idBook, string dateReceived, string datePost, int ticketТumber);
}
