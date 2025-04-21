using System;
using System.Collections.Generic;

namespace ApiBookStore.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdBook { get; set; }

    public string DateReceived { get; set; } = null!;

    public string DatePost { get; set; } = null!;

    public int TickerNumber { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
