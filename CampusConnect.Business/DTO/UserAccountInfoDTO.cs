namespace CampusConnect.Business.DTO;

public class UserAccountInfoDTO
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string passwordHash { get; set; }
}