namespace Projeto3v2.Entidades
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int DuracaoMin { get; set; }
        public string Ano { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}\n" +
                   $" Nome: {this.Nome}\n" +
                   $" Genero: {this.Genero}\n" +
                   $" Duração: {this.DuracaoMin}\n" +
                   $" Ano: {this.Ano}";
        }
    }
}