public class AuthService( TokenProvider tokenProvider)
{

    static string _usuario = "admin";
    static string _contrasenia = "123";

    public string login(string usuario, string contrasenia)
    {
        if (!usuario.Equals(_usuario) && !contrasenia.Equals(_contrasenia))
        {
            throw new Exception("Credenciales incorrectas");    
        } 

        Usuario user = new Usuario(usuario, contrasenia);
        return tokenProvider.GenerarToken(user);
    }

}