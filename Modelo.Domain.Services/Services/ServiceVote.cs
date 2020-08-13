using Modelo.Domain.Core.Interfaces.Repositorys;
using Modelo.Domain.Core.Interfaces.Services;
using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAPI.Util;

namespace Modelo.Domain.Services.Services
{
    public class ServiceVote : ServiceBase<Vote>, IServiceVote
    {
        public readonly IRepositoryVote _repositoryVote;

        public ServiceVote(IRepositoryVote RepositoryVote)
            : base(RepositoryVote)
        {
            _repositoryVote = RepositoryVote;
        }


    }
}
