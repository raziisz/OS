using System.Collections.Generic;

namespace OrdemServico.API.Modelos
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }

        // [Required(ErrorMessage = "Preencher {0}")]
        // [StringLength(40, MinimumLength = 3, ErrorMessage = "Tamanho do {0} deve ser entre {2} a {1} caracteres")]
        public string Nome { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }

        // [Required(ErrorMessage = "Preencher {0}")]
        // [StringLength(30, MinimumLength = 2, ErrorMessage = "Tamanho do {0} deve ser entre {2} a {1} caracteres")]
        public string Cargo { get; set; }
        public ICollection<Servico> Servicos { get; set; }
        public Usuario()
        {
            
        }
    }
}