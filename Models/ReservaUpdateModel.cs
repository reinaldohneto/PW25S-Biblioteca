using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ReservaUpdateModel
    {
        public Guid Id { get; set; }
        public string NomeLocador { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string NomeLivro { get; set; }
        public DateTime DataCadastro { get; set; }

        public ReservaUpdateModel(Guid id, string nomeLocador, DateTime dataDevolucao, string nomeLivro, DateTime dataCadastro)
        {
            Id = id;
            NomeLocador = nomeLocador;
            DataDevolucao = dataDevolucao;
            NomeLivro = nomeLivro;
            DataCadastro = dataCadastro;
        }

        public ReservaUpdateModel()
        {
        }
    }
}
