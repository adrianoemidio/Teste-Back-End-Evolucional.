using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppEvolucional.Models
{
    public class AlunoModel
    {
        [Key]
        [Required]
        public long AlunoID { get; set; }

        [Required]
        public string Nome {get; set;}

    }
}