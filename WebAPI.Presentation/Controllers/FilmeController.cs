using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO.DTO;
using WebAPI.Application.Interfaces;
using WebAPI.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IApplicationServiceMovie _applicationServiceMovie;
        private readonly IApplicationServiceVote _applicationServiceVote;


        public FilmeController(IApplicationServiceMovie ApplicationServiceMovie, IApplicationServiceVote ApplicationServiceVote)
        {
            _applicationServiceMovie = ApplicationServiceMovie;
            _applicationServiceVote = ApplicationServiceVote;
        }

        /// <summary>
        /// Método para obter detalhes de um filme
        /// </summary>
        /// <param name="id"> Id do Filme a ser buscado </param>
        /// <returns>
        /// Retorna um item com os detalhes do filme
        /// </returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<MovieDTO> Get(int id)
        {
            return Ok(_applicationServiceMovie.GetById(id));
        }

        /// <summary>
        /// Método para adicionar filmes
        /// </summary>
        /// <param name="filme">Parâmetro com detalhes do filme</param>
        /// <returns></returns>
        [HttpPost]
        //[Route("cadastrar")]
        [Authorize(Roles = "Admin")]
        public ActionResult Post([FromBody] MovieDTO filme)
        {
            try
            {
                // conferir autenticação e se é admin
                if (filme == null)
                    return BadRequest("Parâmetro não encontrado.");

                _applicationServiceMovie.Add(filme);
                return Ok("Filme Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para cadastro de votos.
        /// </summary>
        /// <param name="vote">Parâmetro com itens para cadastro do voto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("votar")]
        [Authorize(Roles = "Usuario")]
        public ActionResult Votar([FromBody] VoteDTO vote)
        {
            try
            {
                if (vote == null)
                    return BadRequest("Voto não enviado.");

                // pegar o filme por id pra garantir que existe
                var filme = _applicationServiceMovie.GetById(vote.MovieId);
                if (filme == null)
                    return NotFound("Filme não encontrado.");

                // conferir se usuário ta autenticado e pegar id dele


                // conferir se usuário já votou nesse filme, se sim, update, se nao, add
                var votoAntigo = _applicationServiceVote.GetAll().Where(v => v.MovieId == vote.MovieId && v.UserId == vote.UserId).FirstOrDefault();
                if (votoAntigo != null)
                {
                    votoAntigo.Rating = vote.Rating;
                    _applicationServiceVote.Update(votoAntigo);
                }
                else
                {
                    _applicationServiceVote.Add(vote);
                }
                return Ok("Voto Computado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para Listar Filmes
        /// </summary>
        /// <param name="pageParameters">Parâmetros de Paginação</param>
        /// <param name="filterParams">Parâmetros de filtro dos filmes.</param>
        /// <returns>Retorna uma lista de filmes de acordo com os filtros.</returns>
        [HttpGet]
        [Route("listar")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<MovieDTO>> ListarFilmes([FromQuery] PaginationParams pageParameters, [FromQuery] FilterMovie filterParams
            )
        {
            return Ok(_applicationServiceMovie.GetMovies(pageParameters, filterParams));
        }
    }
}
