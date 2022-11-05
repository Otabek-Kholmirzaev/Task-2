using System.ComponentModel.DataAnnotations;

namespace Task_2.Models;

public class CreateUserModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
}
