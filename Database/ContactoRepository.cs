class ContactoRepository : IEntityRepository<Contacto>
{
    private readonly AgendaContext _db;
    
    public ContactoRepository(AgendaContext context)
    {
        _db = context;
    }

    public bool Agregar(Contacto c)
    {
        _db.Contactos.Add(c);
        return Guardar();
    }

    public bool Editar(Contacto c)
    {
        var contactoExistente = Obtener(c.Id);

        if (contactoExistente == null)
            return false;

        contactoExistente.Nombre = c.Nombre;
        contactoExistente.Apellido = c.Apellido;
        contactoExistente.Telefono = c.Telefono;
        contactoExistente.Email = c.Email;

        return Guardar();
    }
    public Contacto Obtener(int id)
    {
        return _db.Contactos.FirstOrDefault(c => c.Id == id);
    }

    public List<Contacto> ObtenerTodos()
    {
        return _db.Contactos.ToList();
    }

    public bool Guardar() {
		return _db.SaveChanges() > 0;
	}

    public Contacto ObtenerPorString(string str)
    {
        throw new NotImplementedException();
    }
}