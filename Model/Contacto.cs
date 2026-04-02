using System.ComponentModel.DataAnnotations;

public class Contacto
{
    public int Id { get; set; }

    [Required]
    public String Nombre { get; set; }  = string.Empty;

    [Required]
    public String Apellido { get; set; }  = string.Empty;

    [Required]
    public String Telefono { get; set; }  = string.Empty;

    public String Email { get; set; }  = string.Empty;
}