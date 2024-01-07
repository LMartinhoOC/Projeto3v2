using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string login {  get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string password { get; set; }
    }
}
