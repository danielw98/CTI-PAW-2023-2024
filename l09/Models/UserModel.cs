using Laborator09.Logic;
using Microsoft.SqlServer.Server;

namespace Laborator09.Models;

public class UserModel
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirm { get; set; }
    public UserType Role { get; set; }
}
