namespace Persistence.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string Identification { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
