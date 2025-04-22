using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public class TicketRequest
    {
        public int id { get; set; }
        public string bookName { get; set; }
        public string dateReceived { get;set; }
        public string datePost { get; set; }
        public int ticketNumber { get; set; }
    }
}
