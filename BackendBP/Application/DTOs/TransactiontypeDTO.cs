using System;
using System.Collections.Generic;

namespace Application.DTOs;

public partial class TransactiontypeDTO
{
    public int TransactionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<TransactionDTO> Transactions { get; } = new List<TransactionDTO>();
}
