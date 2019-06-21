using System;
using System.ComponentModel.DataAnnotations;
using OrdemServico.API.Modelos.Enum;

namespace OrdemServico.API.Modelos
{
    public class Servico
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Preencher {0}")]
        public string Descricao { get; set; }
        public string TipoOrdem { get; set; }
        public ServicoStatus Status { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRegistro { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinalizada { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Servico()
        {
            
        }
        public Servico(int id, string descricao, string tipoOrdem, ServicoStatus status, DateTime dataRegistro, DateTime dataFinalizada, Usuario usuario, int usuarioId)
        {
            Id = id;
            Descricao = descricao;
            TipoOrdem = tipoOrdem;
            Status = status;
            DataRegistro = dataRegistro;
            DataFinalizada = dataFinalizada;
            Usuario = usuario;
            UsuarioId = usuarioId;
        }
    }
}