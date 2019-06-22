using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdemServico.API.Data;
using OrdemServico.API.Dto;
using OrdemServico.API.Helpers;

namespace OrdemServico.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public UsuariosController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios([FromQuery]UsuarioParams usuarioParams)
        {
            var usuarios = await _repo.GetUsuarios(usuarioParams);

            var usuariosLista = _mapper.Map<IEnumerable<UsuarioListaDto>>(usuarios);

            Response.AddPagination(usuarios.CurrentPage, usuarios.PageSize,
                usuarios.TotalCount, usuarios.TotalPages);

            return Ok(usuariosLista);
        }
    }
}