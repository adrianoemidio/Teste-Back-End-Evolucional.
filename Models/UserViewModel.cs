using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppEvolucional.Models
{
    /// <summary>
    /// Modelo de visualização para os dados dos usários do sistema
    /// </summary>
    public class UserViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Insira seu nome de login")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Insira sua senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }



        
    }
}