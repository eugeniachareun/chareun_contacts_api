public class ContactoService
{

    static int nextId = 3;

    List<Contacto> Contactos { get; }

    public ContactoService()
    {
        Contactos = new List<Contacto>
        {
            new Contacto {Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juanperez@mail.com", Telefono = "123-456"},
            new Contacto {Id = 2, Nombre = "Eugenia", Apellido = "Chareun", Email = "eugeniachareun@mail.com", Telefono = "456-123"}
        };
    }

    public List<Contacto> ObtenerTodos() => Contactos;

    public Contacto? ObtenerPorId(int id) => Contactos.FirstOrDefault(c => c.Id == id);

    public Contacto Crear(Contacto contacto)
    {
        contacto.Id = nextId++;
        Contactos.Add(contacto);

        return contacto;
    }

    public bool Editar(int id, Contacto contacto)
    {
        var index = Contactos.FindIndex(c => c.Id == id);

        if (index == -1) return false;

        Contactos[index] = contacto;
        return true;
    }

    public bool Eliminar(int id)
    {
        var contacto = Contactos.Find(c => c.Id == id);

        if (contacto is null) return false;

        return Contactos.Remove(contacto);
    }
}