namespace Application.Features.Clients.Commands.CreateClient;

public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
	public CreateClientValidator()
	{
		RuleFor(c => c.Client.ClientId)
			.Empty();

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

        RuleFor(c => c.Client.Status)
            .Equal(true);
    }
}
