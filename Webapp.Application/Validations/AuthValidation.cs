using Application.Requests;
using FluentValidation;

namespace Webapp.API.Validations;

public class AuthValidation : AbstractValidator<AuthRequest>
{
    public AuthValidation()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull();
    }
}
