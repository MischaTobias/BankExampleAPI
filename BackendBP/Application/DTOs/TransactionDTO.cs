using System;
using System.Collections.Generic;

namespace Application.DTOs;

public partial class TransactionDTO
{
    public int TransactionId { get; set; }

    public int AccountNumber { get; set; }

    public DateTime Date { get; set; }

    public int TransactionTypeId { get; set; }

    public decimal Amount { get; set; }

    public decimal Balance { get; set; }

    public bool Status { get; set; }

    public virtual AccountDTO AccountNumberNavigation { get; set; } = null!;

    public virtual TransactiontypeDTO TransactionType { get; set; } = null!;
}
