namespace Application.DTOs;

public partial class ClientDTO
{
    public int ClientId { get; set; }
    public string Password { get; set; } = null!;
    public int PersonId { get; set; }
    public string Identification { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public int Age { get; set; }
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public bool Status { get; set; } = true;
}
