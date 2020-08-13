using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;

namespace WebAPI.Infra.Cross.Adapter.Interfaces
{
    public interface IMapperMovie
    {
        #region Mappers

        Movie MapperToEntity(MovieDTO MovieDTO);

        IEnumerable<MovieDTO> MapperListMovies(IEnumerable<Movie> Movies);

        MovieDTO MapperToDTO(Movie User);

        #endregion
    }
}
