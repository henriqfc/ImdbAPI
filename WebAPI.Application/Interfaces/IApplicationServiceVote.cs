using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Util;

namespace WebAPI.Application.Interfaces
{
    public interface IApplicationServiceVote
    {
        void Add(VoteDTO obj);

        VoteDTO GetById(int id);

        IEnumerable<VoteDTO> GetAll();
        
        void Update(VoteDTO obj);

        void Remove(VoteDTO obj);

        void Dispose();

    }
}
