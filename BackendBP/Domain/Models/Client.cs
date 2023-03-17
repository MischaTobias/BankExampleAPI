namespace Domain.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Password { get; set; } = null!;

    public bool Status { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual Person Person { get; set; } = null!;
}
