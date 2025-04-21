using System;
using System.Collections.Generic;

namespace ApiBookStore.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int? IdBook { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
