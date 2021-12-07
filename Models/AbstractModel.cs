using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AbstractModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
