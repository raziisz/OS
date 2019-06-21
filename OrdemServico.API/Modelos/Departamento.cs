using System.Collections.Generic;

namespace OrdemServico.API.Modelos
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuario> Usuario { get; set; }

        public Departamento()
        {
            
        }

        public Departamento(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}