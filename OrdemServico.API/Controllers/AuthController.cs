using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrdemServico.API.Data;
using OrdemServico.API.Dto;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;

        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistroDto usuarioRegistroDto)
        {
            usuarioRegistroDto.Login = usuarioRegistroDto.Login.ToLower();

            if (await _repo.UsuarioExiste(usuarioRegistroDto.Login))
                return BadRequest("Login já existe");

            var usuarioParaCriacao = new Usuario
            {
                Login = usuarioRegistroDto.Login
            };
            return null;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            var usuarioRepo = await _repo.Login(usuarioLoginDto.Login.ToLower(), usuarioLoginDto.Senha);

            if (usuarioRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, usuarioRepo.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var usuario = _mapper.Map<Usuario>(usuarioRepo);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                usuario
            });
        }

    }
}