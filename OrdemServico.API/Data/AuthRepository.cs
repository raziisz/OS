using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Usuario> Login(string login, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == login);

            if (usuario == null)
                return null;

            if (!VerificarSenhaHash(senha, usuario.SenhaHash, usuario.SenhaSalt))
                return null;

            return usuario;
        }

        private bool VerificarSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(senhaSalt))
            {
                var computadoHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                for (int i = 0; i < computadoHash.Length; i++)
                {
                    if (computadoHash[i] != senhaHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Usuario> Registrar(Usuario usuario, string senha)
        {
            byte[] senhaHash, senhaSalt;
            CriarSenhaHash(senha, out senhaHash, out senhaSalt);

            usuario.SenhaHash = senhaHash;
            usuario.SenhaSalt = senhaSalt;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public async Task<bool> UsuarioExiste(string login)
        {
           if(await _context.Usuarios.AnyAsync(x => x.Login == login))
                return true;
            return false;
        }
    }
}