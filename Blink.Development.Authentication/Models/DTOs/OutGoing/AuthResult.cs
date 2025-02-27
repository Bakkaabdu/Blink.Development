namespace Blink.Development.Authentication.Models.DTOs.OutGoing;

public class AuthResult
{
    public string Token { get; set; }
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
}
