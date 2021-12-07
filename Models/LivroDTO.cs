using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class LivroDTO
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string NomeAutor { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
