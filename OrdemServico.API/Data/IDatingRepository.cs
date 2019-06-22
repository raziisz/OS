using System.Collections.Generic;
using System.Threading.Tasks;
using OrdemServico.API.Helpers;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Usuario>> GetUsuarios(UsuarioParams usuarioParams);
    }
}