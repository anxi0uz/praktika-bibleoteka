using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public class Ticket
    {
        public int id { get; set; }

        public int idUser { get; set; }

        public int idBook { get; set; }

        public string dateReceived { get; set; } = null!;

        public string datePost { get; set; } = null!;

        public int tickerNumber { get; set; }
    }
}
