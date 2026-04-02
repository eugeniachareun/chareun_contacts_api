using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public Usuario(string username, string contrasenia)
    {
        Username = username;
        Contrasenia = contrasenia;
    }

    public int Id { get; set; }

    [Required]
    public String Username { get; set; }  = string.Empty;

    [Required]
    public String Contrasenia { get; set; }  = string.Empty;

    [Required]
    public string Rol { get; set; }  = Roles.OPERADOR;
}