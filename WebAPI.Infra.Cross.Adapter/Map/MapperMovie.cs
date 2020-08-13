using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Infra.Cross.Adapter.Interfaces;

namespace WebAPI.Infra.Cross.Adapter.Map
{
    public class MapperMovie : IMapperMovie
    {
        #region properties

        List<MovieDTO> MovieDTOs = new List<MovieDTO>();
        MapperVote mv = new MapperVote();

        #endregion


        #region methods

        public Movie MapperToEntity(MovieDTO MovieDTO)
        {
            Movie Movie = new Movie
            {
                Id = MovieDTO.Id,
                Active = MovieDTO.Active,
                DateInsert = MovieDTO.DateInsert,
                DateUpdate = MovieDTO.DateUpdate,
                Name = MovieDTO.Name,
                Actors = MovieDTO.Actors,
                Director = MovieDTO.Director,
                Genre = MovieDTO.Genre,
                Votes = mv.MapperListVotesDTO(MovieDTO.Votes)
            };

            return Movie;

        }


        public IEnumerable<MovieDTO> MapperListMovies(IEnumerable<Movie> Movies)
        {
            foreach (var item in Movies)
            {


                MovieDTO MovieDTO = new MovieDTO
                {
                    Id = item.Id
                   ,
                    Active = item.Active,
                    Name = item.Name,
                    DateUpdate = item.DateUpdate,
                    DateInsert = item.DateInsert,
                    Actors = item.Actors,
                    Director = item.Director,
                    Genre = item.Genre,
                    Votes = mv.MapperListVotes(item.Votes)
                };



                MovieDTOs.Add(MovieDTO);

            }

            return MovieDTOs;
        }

        public MovieDTO MapperToDTO(Movie Movie)
        {

            MovieDTO MovieDTO = new MovieDTO
            {
                Id = Movie.Id
                ,
                Active = Movie.Active,
                DateInsert = Movie.DateInsert,
                DateUpdate = Movie.DateUpdate,
                Name = Movie.Name,
                Actors = Movie.Actors,
                Votes = mv.MapperListVotes(Movie.Votes),
                Genre = Movie.Genre,
                Director = Movie.Director

            };

            return MovieDTO;

        }

        #endregion
    }
}
