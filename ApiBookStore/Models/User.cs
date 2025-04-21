using System;
using System.Collections.Generic;

namespace ApiBookStore.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public string Fio { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
