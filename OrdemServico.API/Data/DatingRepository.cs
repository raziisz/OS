using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdemServico.API.Helpers;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<PagedList<Usuario>> GetUsuarios(UsuarioParams usuarioParams)
        {
            var usuarios =  _context.Usuarios.Include(x => x.Departamento);

            return await PagedList<Usuario>.CreateAsync(usuarios, usuarioParams.PageNumber, usuarioParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}