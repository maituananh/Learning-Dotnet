using FluentValidation;

namespace Webapp.Infra.Configuration;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public Logging Logging { get; set; } = new();
    public string AllowedHosts { get; set; } = string.Empty;
    public JwtSettings Jwt { get; set; } = new();
}

public class ConnectionStrings
{
    public string DatabaseUrl { get; set; } = string.Empty;
    public string Redis { get; set; } = string.Empty;
}

public class Logging
{
    public LogLevel LogLevel { get; set; } = new();
}

public class LogLevel
{
    public string Default { get; set; } = "Information";
    public string MicrosoftAspNetCore { get; set; } = "Warning";
}

public class JwtSettings
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
}

public class AppSettingsValidator : AbstractValidator<AppSettings>
{
    public AppSettingsValidator()
    {
        RuleFor(x => x.ConnectionStrings.DatabaseUrl)
            .NotEmpty().WithMessage("DatabaseUrl is not blank.");

        RuleFor(x => x.ConnectionStrings.Redis)
            .NotEmpty().WithMessage("Redis connection is not define.");

        RuleFor(x => x.Jwt.Key)
            .MinimumLength(32).WithMessage("Jwt Key must be 32 characters.");

        RuleFor(x => x.Jwt.Issuer).NotEmpty();
    }
}