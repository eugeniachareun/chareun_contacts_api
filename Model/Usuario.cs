using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public Usuario(string email, string contrasenia)
    {
        Email = email;
        Contrasenia = contrasenia;
    }

    public int Id { get; set; }

    [Required]
    public String Email { get; set; }  = string.Empty;

    [Required]
    public String Contrasenia { get; set; }  = string.Empty;

}