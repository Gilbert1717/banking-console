namespace s3665887_a1.DTOs;

public class Login
{
    public string LoginID { get; }
    public string PasswordHash { get; }

    public Login(string loginId, string passwordHash)
    {
        LoginID = loginId;
        PasswordHash = passwordHash;
    }
}