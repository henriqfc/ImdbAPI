using Modelo.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Application.Interfaces;
using WebAPI.Infra.Cross.Adapter.Interfaces;
using WebAPI.Util;

namespace WebAPI.Application.Services
{
    public class ApplicationServiceMovie : IApplicationServiceMovie
    {
        private readonly IServiceMovie _serviceMovie;
        private readonly IMapperMovie _mapperMovie;

        public ApplicationServiceMovie(IServiceMovie ServiceMovie
                                                 , IMapperMovie MapperMovie)

        {
            _serviceMovie = ServiceMovie;
            _mapperMovie = MapperMovie;
        }


        public void Add(MovieDTO obj)
        {
            var objMovie = _mapperMovie.MapperToEntity(obj);
            _serviceMovie.Add(objMovie);
        }

        public void Dispose()
        {
            _serviceMovie.Dispose();
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            var objProdutos = _serviceMovie.GetAll();
            return _mapperMovie.MapperListMovies(objProdutos);
        }

        public MovieDTO GetById(int id)
        {
            var objMovie = _serviceMovie.GetById(id);
            return _mapperMovie.MapperToDTO(objMovie);
        }

        public IEnumerable<MovieDTO> GetMovies(PaginationParams MovieParams, FilterMovie filterMovies)
        {
            var objProdutos = _serviceMovie.GetAll();
            if (MovieParams.PageNumber != null && MovieParams.PageSize != null)
            {
                objProdutos = objProdutos.Skip((MovieParams.PageNumber.Value - 1) * MovieParams.PageSize.Value)
                .Take(MovieParams.PageSize.Value).ToList();
            }
            if (filterMovies != null)
            {
                if (!string.IsNullOrEmpty(filterMovies.diretor))
                {
                    objProdutos = objProdutos.Where(f => f.Director.ToLower().Contains(filterMovies.diretor.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(filterMovies.genero))
                {
                    objProdutos = objProdutos.Where(f => f.Genre.ToLower().Contains(filterMovies.genero.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(filterMovies.nome))
                {
                    objProdutos = objProdutos.Where(f => f.Name.ToLower().Contains(filterMovies.nome.ToLower())).ToList();
                }
                if (!string.IsNullOrEmpty(filterMovies.ator))
                {
                    objProdutos = objProdutos.Where(f => f.Actors.ToLower().Contains(filterMovies.ator.ToLower())).ToList();
                }
            }
            objProdutos = objProdutos.OrderBy(on => on.Name).OrderByDescending(on => on.Votes.Count).ToList();
            return _mapperMovie.MapperListMovies(objProdutos);
        }

        public void Remove(MovieDTO obj)
        {
            var objMovie = _mapperMovie.MapperToEntity(obj);
            _serviceMovie.Remove(objMovie);
        }

        public void Update(MovieDTO obj)
        {
            var objMovie = _mapperMovie.MapperToEntity(obj);
            _serviceMovie.Update(objMovie);
        }
        
    }
}
