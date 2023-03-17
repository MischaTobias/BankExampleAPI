namespace Application.DTOs;

public partial class AccountDTO
{
    public int AccountNumber { get; set; }

    public int ClientId { get; set; }

    public int AccountTypeId { get; set; }

    public decimal InitialBalance { get; set; }

    public bool Status { get; set; }

    public virtual AccounttypeDTO AccountType { get; set; } = null!;

    public virtual ClientDTO Client { get; set; } = null!;

    public virtual ICollection<TransactionDTO> Transactions { get; } = new List<TransactionDTO>();
}
