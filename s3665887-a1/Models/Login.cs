namespace s3665887_a1.Models;

public class Login
{
    public required string LoginID { get; init; }
    public int CustomerID { get; init; }
    public required string PasswordHash { get; init; }

    public Login()
    {
    }

    public Login(string loginId, int customerId, string passwordHash)
    {
        LoginID = loginId;
        CustomerID = customerId;
        PasswordHash = passwordHash;
    }
}