using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsuarios()
        {
            if (!_context.Usuarios.Any())
            {
                var usuariosData = System.IO.File.ReadAllText("Data/UsuarioSeed.json");
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(usuariosData);

                foreach (var usuario in usuarios)
                {
                    byte[] senhaHash, senhaSalt;
                    CreateSenhaHash("password", out senhaHash, out senhaSalt);

                    usuario.SenhaHash = senhaHash;
                    usuario.SenhaSalt = senhaSalt;
                    usuario.Login = usuario.Login.ToLower();

                    _context.Usuarios.Add(usuario);
                }

                _context.SaveChanges();

            }
        }
        private void CreateSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }

        }

    }
}
