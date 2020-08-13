using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;

namespace WebAPI.Infra.Cross.Adapter.Interfaces
{
    public interface IMapperVote
    {
        #region Mappers

        Vote MapperToEntity(VoteDTO VoteDTO);

        ICollection<VoteDTO> MapperListVotes(IEnumerable<Vote> Votes);

        VoteDTO MapperToDTO(Vote Vote);

        #endregion
    }
}
