using OrdemServico.API.Modelos;

namespace OrdemServico.API.Dto
{
    public class UsuarioListaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DepartamentoDescricao { get; set; }
        public string Cargo { get; set; }
    }
}