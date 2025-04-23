using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_client.Models
{
    public record BookRequest(string Title, int authorId, string publishDate, int genreId, decimal price);
}
