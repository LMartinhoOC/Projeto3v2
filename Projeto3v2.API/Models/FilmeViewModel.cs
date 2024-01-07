using System.ComponentModel.DataAnnotations;

namespace Projeto3v2.API.Models
{
    public class FilmeViewModel
    {
        [Required (ErrorMessage = "O número do ID do filme é obrigatório")]
        public int         ID           { get; set; }
        [Required (ErrorMessage = "O nome do filme é obrigatório")]
        public string      Nome         { get; set; }
        [Required (ErrorMessage = "O gênero do filme é obrigatório")]
        public string      Genero       { get; set; }
        [Required (ErrorMessage = "A duração do filme é obrigatória ")]
        public int         DuracaoMin   { get; set; }
        public string      Ano          { get; set; }

    }
}