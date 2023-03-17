using System;
using System.Collections.Generic;

namespace Application.DTOs;

public partial class AccounttypeDTO
{
    public int AccountTypeId { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<AccountDTO> Accounts { get; } = new List<AccountDTO>();
}
