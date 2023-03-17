namespace Persistence.Models;

public partial class Account
{
    public int AccountNumber { get; set; }

    public int ClientId { get; set; }

    public int AccountTypeId { get; set; }

    public decimal InitialBalance { get; set; }

    public bool? Status { get; set; }

    public virtual Accounttype AccountType { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();
}
