public class ContactoService
{
    private readonly IEntityRepository<Contacto> _repo;

    public ContactoService(IEntityRepository<Contacto> repo)
    {
        _repo = repo;
    }

    public List<Contacto> ObtenerTodos()
    {
        return _repo.ObtenerTodos();
    }

    public Contacto? ObtenerPorId(int id)
    {
        return _repo.Obtener(id);
    }

    public Contacto? Crear(Contacto contacto)
    {
        var ok = _repo.Agregar(contacto);

        if (!ok)
            return null;

        return contacto;
    }

    public bool Editar(int id, Contacto contacto)
    {
        var contactoExistente = _repo.Obtener(id);

        if (contactoExistente == null)
            return false;

        contacto.Id = id;

        return _repo.Editar(contacto);
    }

    public bool Eliminar(int id)
    {
        throw new NotImplementedException();
    }
}