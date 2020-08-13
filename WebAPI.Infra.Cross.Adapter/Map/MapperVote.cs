using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Infra.Cross.Adapter.Interfaces;

namespace WebAPI.Infra.Cross.Adapter.Map
{
    public class MapperVote : IMapperVote
    {
        #region properties

        List<VoteDTO> VoteDTOs = new List<VoteDTO>();
        List<Vote> ListVotes = new List<Vote>();
        //MapperMovie mm = new MapperMovie();
        MapperUser u = new MapperUser();

        #endregion


        #region methods

        public Vote MapperToEntity(VoteDTO VoteDTO)
        {
            Vote Vote = new Vote
            {
                Id = VoteDTO.Id,
                Active = VoteDTO.Active,
                DateInsert = VoteDTO.DateInsert,
                DateUpdate = VoteDTO.DateUpdate,
                //Movie = mm.MapperToEntity(VoteDTO.Movie),
                //User = u.MapperToEntity(VoteDTO.User),
                UserId = VoteDTO.UserId,
                MovieId = VoteDTO.MovieId,
                Rating = VoteDTO.Rating
            };

            return Vote;

        }
        public ICollection<Vote> MapperListVotesDTO(IEnumerable<VoteDTO> Votes)
        {
            foreach (var item in Votes)
            {


                Vote Vote = new Vote
                {
                    Id = item.Id
                   ,
                    Active = item.Active,
                    //Movie = mm.MapperToEntity(item.Movie),
                    MovieId = item.MovieId,
                    UserId = item.UserId,
                    //User = u.MapperToEntity(item.User),
                    Rating = item.Rating,
                    DateUpdate = item.DateUpdate,
                    DateInsert = item.DateInsert
                };



                ListVotes.Add(Vote);

            }

            return ListVotes;
        }

        public ICollection<VoteDTO> MapperListVotes(IEnumerable<Vote> Votes)
        {
            VoteDTOs = new List<VoteDTO>();
            if (Votes != null)
            {
                foreach (var item in Votes)
                {


                    VoteDTO VoteDTO = new VoteDTO
                    {
                        Id = item.Id
                       ,
                        Active = item.Active,
                        //Movie = mm.MapperToDTO(item.Movie),
                        MovieId = item.MovieId,
                        UserId = item.UserId,
                        //User = u.MapperToDTO(item.User),
                        Rating = item.Rating,
                        DateUpdate = item.DateUpdate,
                        DateInsert = item.DateInsert
                    };



                    VoteDTOs.Add(VoteDTO);

                }
            }

            return VoteDTOs;
        }

        public VoteDTO MapperToDTO(Vote Vote)
        {

            VoteDTO VoteDTO = new VoteDTO
            {
                Id = Vote.Id
                ,
                Active = Vote.Active,
                DateInsert = Vote.DateInsert,
                DateUpdate = Vote.DateUpdate,
                //Movie = mm.MapperToDTO(Vote.Movie),
                MovieId = Vote.MovieId,
                //User = u.MapperToDTO(Vote.User),
                UserId = Vote.UserId,
                Rating = Vote.Rating

            };

            return VoteDTO;

        }

        #endregion
    }
}
