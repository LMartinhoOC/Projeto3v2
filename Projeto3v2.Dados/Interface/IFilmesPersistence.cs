using Projeto3v2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3v2.Dados.Interface
{
    public interface IFilmesPersistence
    {
        List<Filme> ObterListaFilmes();
        Filme ObterFilmePorId(int id);
        void InserirFilme(Filme filme);
        void AtualizarFilme(Filme filme);
        void ExcluirFilme(Filme filme);
    }
}
