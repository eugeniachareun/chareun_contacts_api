public interface IContactoRepository
{
    public List<Contacto> ObtenerTodos();

    public Contacto Obtener(int id);

    public bool Agregar(Contacto c);
    public bool Editar(Contacto c);
}