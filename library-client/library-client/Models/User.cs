using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public class User
    {
        public int id { get; set; }

        public string fio { get; set; }

        public string birthDate { get; set; }

        public string adress { get; set; }

        public string phoneNumber { get; set; }
        public int roleId { get; set; }
    }
}
