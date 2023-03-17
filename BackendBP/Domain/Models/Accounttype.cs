using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Accounttype
{
    public int AccountTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
