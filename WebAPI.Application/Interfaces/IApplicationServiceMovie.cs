using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Util;

namespace WebAPI.Application.Interfaces
{
    public interface IApplicationServiceMovie
    {
        void Add(MovieDTO obj);

        MovieDTO GetById(int id);

        IEnumerable<MovieDTO> GetAll();
        IEnumerable<MovieDTO> GetMovies(PaginationParams MovieParams, FilterMovie filterMovies);
        
        void Update(MovieDTO obj);

        void Remove(MovieDTO obj);

        void Dispose();

    }
}
