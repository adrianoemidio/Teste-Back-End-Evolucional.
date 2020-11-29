using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppEvolucional.Models
{
    public class NotasModel
    {
        [Key]
        [Required]
        public long NotasID { get; set;}
        
        [Required]
        public long AlunoID { get; set; }
        public double Matematica{get; set;}
        public double Portugues{get; set;}
        public double Historia{get; set;}
        public double Geografia{get; set;}
        public double Ingles{get; set;}
        public double Biologia{get; set;}
        public double Filosofia{get; set;}
        public double Fisica{get; set;}
        public double Quimica{get; set;}
    }
}