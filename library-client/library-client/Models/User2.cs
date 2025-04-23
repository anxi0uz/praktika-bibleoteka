using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public class User2
    {
        public string login { get; set; }
        public string password { get; set; }

        public string fio { get; set; }

        public string birthday { get; set; }

        public string adress { get; set; }

        public string phone { get; set; }
        public int role { get; set; }
    }
}
