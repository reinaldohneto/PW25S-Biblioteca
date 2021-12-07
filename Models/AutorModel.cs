using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AutorModel : AbstractModel
    {
        public string NomeAutor { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<LivroModel> Livros { get; set; }
    }
}
