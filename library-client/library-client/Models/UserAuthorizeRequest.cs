using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public class UserAuthorizeRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
