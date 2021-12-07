using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ReservaModel : AbstractModel
    {
        public string NomeLocador { get; set; }
        public DateTime DataDevolucao { get; set; } = DateTime.Now.AddDays(7);
        public LivroModel Livro { get; set; }
        public Guid LivroId { get; set; }
    }
}
