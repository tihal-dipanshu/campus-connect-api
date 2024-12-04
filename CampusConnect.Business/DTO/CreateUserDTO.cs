namespace CampusConnect.Business.DTO;

public class CreateUserDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string passwordHash { get; set; }
    public string userRole { get; set; }
}