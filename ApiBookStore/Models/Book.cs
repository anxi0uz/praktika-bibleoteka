using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiBookStore.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public string PublishDate { get; set; } = null!;

    public int GenreId { get; set; }

    public decimal? Price { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
