using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class LivroUpdateModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string NomeAutor { get; set; }
        public DateTime DataCadastro { get; set; }

        public LivroUpdateModel(Guid id, string nome, int ano, string nomeAutor, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Ano = ano;
            NomeAutor = nomeAutor;
            DataCadastro = dataCadastro;
        }

        public LivroUpdateModel()
        {
        }
    }
}
