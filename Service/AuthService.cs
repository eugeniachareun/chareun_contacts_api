
/*
* PARA MEJORAR: HASHEAR LAS CONTRASEÑAS POR SEGURIDAD
*/
public class AuthService( TokenProvider tokenProvider, IEntityRepository<Usuario> repository)
{

    public string login(LoginRequest request)
    {
        Usuario? user = repository.ObtenerPorString(request.Email);
        
        if (user == null)
        {
            throw new Exception("El email indicado no existe.");  
        }

        if (!request.Email.Equals(user.Email) && !request.Password.Equals(user.Contrasenia))
        {
            throw new Exception("Credenciales incorrectas");    
        } 

        return tokenProvider.GenerarToken(user);
    }

    public string register(Usuario usuario)
    {
        Usuario? user = repository.ObtenerPorString(usuario.Email);

        if (user != null)
        {
            throw new Exception("Email ya registrado");  
        }

        Usuario newUser = new Usuario(usuario.Email, usuario.Contrasenia);
        bool result = repository.Agregar(newUser);

        if (result)
        {
            return "Usuario creado. Por favor, iniciá sesión.";
        } else
        {
            throw new Exception("Error al crear el usuario");
        }


    }

}