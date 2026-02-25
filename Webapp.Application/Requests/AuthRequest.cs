namespace Application.Requests;

public class AuthRequest
{
    //[Required(ErrorMessage = "UserName is required")]
    public string Username { get; set; }

    //[Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
