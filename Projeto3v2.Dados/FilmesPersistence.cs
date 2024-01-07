using Microsoft.Extensions.Configuration;
using Projeto3v2.Dados.Interface;
using Projeto3v2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3v2.Dados
{
    public class FilmesPersistence : IFilmesPersistence
    {
        private readonly IConfiguration _configuration;
        protected        SqlConnection  Con { get; set; }
        protected        SqlCommand     Cmd { get; set; }
        protected        SqlDataReader  Dr  { get; set; }
        protected        SqlTransaction Tr  { get; set; }

        public FilmesPersistence(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        private void AbrirConexao()
        {
            if (Con == null)
            {
                Con = new SqlConnection(this._configuration.GetConnectionString("Conexao"));
                Con.Open();
            }
            else
            {
                Con.Open();
            }
        }

        private void FecharConexao()
        {
            if(Con != null)
            {
                    Con.Close();
                    Con = null;
            }
        }

        public void AtualizarFilme(Filme filme)
        {
            try
            {
                AbrirConexao();

                string query = "UPDATE TB_FILMES_MENTORIA " +
                  "SET NOME       = @NOME" +
                  " ,GENERO       = @GENERO " +
                  " ,DURACAO      = @DURACAO" +
                  " ,ANO          = @ANO" +
                  " WHERE ID = @ID";

                this.Cmd = new SqlCommand(query, Con);
                this.Cmd.Parameters.AddWithValue("@ID"      , filme.Id);
                this.Cmd.Parameters.AddWithValue("@NOME"    , filme.Nome);
                this.Cmd.Parameters.AddWithValue("@GENERO"  , filme.Genero);
                this.Cmd.Parameters.AddWithValue("@DURACAO" , filme.DuracaoMin);
                this.Cmd.Parameters.AddWithValue("@ANO"     , filme.Ano);
                this.Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluirFilme(Filme filme)
        {
            try
            {
                AbrirConexao();

                string query = "DELETE FROM TB_FILMES_MENTORIA WHERE ID = @ID";

                this.Cmd = new SqlCommand(query, Con);
                this.Cmd.Parameters.AddWithValue("@ID", filme.Id);
                this.Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void InserirFilme(Filme filme)
        {
            try
            {
                AbrirConexao();

                string query = "INSERT INTO [dbo].[TB_FILMES_MENTORIA]" +
                    "(Id, NOME, GENERO, DURACAO, ANO)" +
                    "VALUES" +
                    "(@ID, @NOME, @GENERO, @DURACAO, @ANO)";

                this.Cmd = new SqlCommand(query, Con);
                this.Cmd.Parameters.AddWithValue("@ID", filme.Id);
                this.Cmd.Parameters.AddWithValue("@NOME", filme.Nome);
                this.Cmd.Parameters.AddWithValue("@GENERO", filme.Genero);
                this.Cmd.Parameters.AddWithValue("@DURACAO", filme.DuracaoMin);
                this.Cmd.Parameters.AddWithValue("@ANO", filme.Ano);
                this.Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public Filme ObterFilmePorId(int id)
        {
            try
            {
                AbrirConexao();

                Filme filme = null;

                string query = "SELECT * FROM TB_FILMES_MENTORIA WHERE ID = @ID";

                this.Cmd = new SqlCommand(query, Con);
                this.Cmd.Parameters.AddWithValue("@ID", id);
                this.Dr = Cmd.ExecuteReader();

                while (Dr.Read())
                {
                    filme            = new Filme();
                    filme.Id         = (int)Dr["ID"];
                    filme.Nome       = (string)Dr["NOME"];
                    filme.Genero     = (string)Dr["GENERO"];
                    filme.DuracaoMin = (int)Dr["DURACAO"];
                    filme.Ano        = (string)Dr["ANO"];
                }
                Dr.Close();

                return filme;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Filme> ObterListaFilmes()
        {
            try
            {
                AbrirConexao();

                List<Filme> lista = new List<Filme>();

                string query = "SELECT * FROM TB_FILMES_MENTORIA";

                this.Cmd = new SqlCommand(query, Con);
                this.Dr = Cmd.ExecuteReader();

                while (Dr.Read())
                {
                    Filme filme = new Filme();
                    filme = new Filme();
                    filme.Id = (int)Dr["ID"];
                    filme.Nome = (string)Dr["NOME"];
                    filme.Genero = (string)Dr["GENERO"];
                    filme.DuracaoMin = (int)Dr["DURACAO"];
                    filme.Ano = (string)Dr["ANO"];

                    lista.Add(filme);
                }

                Dr.Close();
                return lista;
            }
            catch(Exception e) 
            {
                throw; 
            }
            finally
            {
                FecharConexao();
            }
        }
        
    }
}