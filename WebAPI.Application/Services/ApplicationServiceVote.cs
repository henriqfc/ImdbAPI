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
    public class ApplicationServiceVote : IApplicationServiceVote
    {
        private readonly IServiceVote _serviceVote;
        private readonly IMapperVote _mapperVote;

        public ApplicationServiceVote(IServiceVote ServiceVote
                                                 , IMapperVote MapperVote)

        {
            _serviceVote = ServiceVote;
            _mapperVote = MapperVote;
        }


        public void Add(VoteDTO obj)
        {
            var objVote = _mapperVote.MapperToEntity(obj);
            _serviceVote.Add(objVote);
        }

        public void Dispose()
        {
            _serviceVote.Dispose();
        }

        public IEnumerable<VoteDTO> GetAll()
        {
            var objProdutos = _serviceVote.GetAll();
            return _mapperVote.MapperListVotes(objProdutos);
        }

        public VoteDTO GetById(int id)
        {
            var objVote = _serviceVote.GetById(id);
            return _mapperVote.MapperToDTO(objVote);
        }

      
        public void Remove(VoteDTO obj)
        {
            var objVote = _mapperVote.MapperToEntity(obj);
            _serviceVote.Remove(objVote);
        }

        public void Update(VoteDTO obj)
        {
            var objVote = _mapperVote.MapperToEntity(obj);
            _serviceVote.Update(objVote);
        }
        
    }
}
