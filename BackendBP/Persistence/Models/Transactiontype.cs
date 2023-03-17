using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Transactiontype
{
    public int TransactionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();
}
