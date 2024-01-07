using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto3v2.API.Models;
using Projeto3v2.Dados.Interface;
using Projeto3v2.Entidades;
using System.ComponentModel;

namespace Projeto3v2.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmesPersistence _filmePersistence;

        public FilmeController(IFilmesPersistence filmePersistence)
        {
            this._filmePersistence = filmePersistence;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetFilmes()
        {
            try
            {
                List<Filme> filmes = this._filmePersistence.ObterListaFilmes();

                List<FilmeViewModel> lista = new List<FilmeViewModel>();

                foreach (Filme filme in filmes)
                {
                    lista.Add(new FilmeViewModel()
                    {
                        ID = filme.Id,
                        Nome = filme.Nome,
                        Genero = filme.Genero,                        
                        DuracaoMin = filme.DuracaoMin,
                        Ano = filme.Ano
                    });
                }
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetFilme(int id)
        {
            try
            {
                Filme filme = this._filmePersistence.ObterFilmePorId(id);

                if(filme == null)
                {
                    return NotFound();
                }
                else
                {
                    FilmeViewModel model = new FilmeViewModel()
                    {
                        ID = filme.Id,
                        Nome = filme.Nome,
                        Genero = filme.Genero,
                        DuracaoMin = filme.DuracaoMin,
                        Ano = filme.Ano
                    };

                    return Ok(model);
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult InserirFilme(FilmeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            
                else
                {
                    Filme filme = new Filme()
                    {
                        Id = model.ID,
                        Nome = model.Nome,
                        Genero = model.Genero,
                        DuracaoMin = model.DuracaoMin,
                        Ano = model.Ano
                    };

                    this._filmePersistence.InserirFilme(filme);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult AtualizarFilme(FilmeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    Filme filme = new Filme()
                    {
                        Id = model.ID,
                        Nome = model.Nome,
                        Genero = model.Genero,
                        DuracaoMin = model.DuracaoMin,
                        Ano = model.Ano
                    };

                    this._filmePersistence.AtualizarFilme(filme);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult ExcluirFilme(int id)
        {
            try
            {
                Filme filme = this._filmePersistence.ObterFilmePorId(id);

                if(filme == null)
                {
                    return NotFound();
                }
                else
                {
                    this._filmePersistence.ExcluirFilme(filme);
                    return Ok();
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
