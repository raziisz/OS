using System.Threading.Tasks;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Data
{
    public interface IAuthRepository
    {
         Task<Usuario> Registrar(Usuario usuario, string senha);
         Task<Usuario> Login(string login, string senha);
         Task<bool> UsuarioExiste(string login);
    }
}