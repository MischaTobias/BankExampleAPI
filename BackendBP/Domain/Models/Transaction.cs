using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int AccountNumber { get; set; }

    public DateTime Date { get; set; }

    public int TransactionTypeId { get; set; }

    public decimal Amount { get; set; }

    public decimal Balance { get; set; }

    public bool Status { get; set; }

    public virtual Account AccountNumberNavigation { get; set; } = null!;

    public virtual Transactiontype TransactionType { get; set; } = null!;
}
