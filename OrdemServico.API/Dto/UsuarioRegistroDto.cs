namespace OrdemServico.API.Dto
{
    public class UsuarioRegistroDto
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        // [Required(ErrorMessage = "Preencher {0}")]
        // [StringLength(40, MinimumLength = 3, ErrorMessage = "Tamanho do {0} deve ser entre {2} a {1} caracteres")]
        public string Nome { get; set; }
        public int DepartamentoId { get; set; }

        // [Required(ErrorMessage = "Preencher {0}")]
        // [StringLength(30, MinimumLength = 2, ErrorMessage = "Tamanho do {0} deve ser entre {2} a {1} caracteres")]
        public string Cargo { get; set; }
    }
}