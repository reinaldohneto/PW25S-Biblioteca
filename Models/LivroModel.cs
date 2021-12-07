using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class LivroModel : AbstractModel
    {
        public string Nome { get; set; }
        public int AnoLancamento { get; set; }
        public ReservaModel Reserva { get; set; }
        public AutorModel Autor { get; set; }
        public Guid AutorId { get; set; }
    }
}
