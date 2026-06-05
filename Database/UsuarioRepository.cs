class UsuarioRepository : IEntityRepository<Usuario>
{
    private readonly AgendaContext _db;
    
    public UsuarioRepository(AgendaContext context)
    {
        _db = context;
    }

    public bool Agregar(Usuario c)
    {
        _db.Usuarios.Add(c);
        return Guardar();
    }

    public bool Editar(Usuario c)
    {
        throw new NotImplementedException();
    }
    public Usuario Obtener(int id)
    {
        throw new NotImplementedException();
    }

    public List<Usuario> ObtenerTodos()
    {
        return _db.Usuarios.ToList();
    }

    public bool Guardar() {
		return _db.SaveChanges() > 0;
	}

    public Usuario ObtenerPorString(string str)
    {
        return _db.Usuarios.FirstOrDefault(u => u.Email == str);
    }
}