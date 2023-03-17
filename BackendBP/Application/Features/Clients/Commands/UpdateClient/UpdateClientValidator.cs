namespace Application.Features.Clients.Commands.UpdateClient;

public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientValidator()
    {
        RuleFor(c => c.Client.ClientId)
            .NotEmpty();

        RuleFor(c => c.Client.Password)
            .NotEmpty();

        RuleFor(c => c.Client.Identification)
            .NotEmpty();

        RuleFor(c => c.Client.Name)
            .NotEmpty();

        RuleFor(c => c.Client.Gender)
            .NotEmpty();

        RuleFor(c => c.Client.Age)
            .Cascade(CascadeMode.Stop)
            .GreaterThanOrEqualTo(18)
            .LessThanOrEqualTo(70);

        RuleFor(c => c.Client.Address)
            .NotEmpty();

        RuleFor(c => c.Client.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Matches("[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}");
    }
}
