public interface IEntityRepository<T>
{
    public List<T> ObtenerTodos();

    public T Obtener(int id);

    public T ObtenerPorString(string str);

    public bool Agregar(T e);
    public bool Editar(T e);
}