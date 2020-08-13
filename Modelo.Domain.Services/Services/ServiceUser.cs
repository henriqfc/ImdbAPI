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
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        public readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser RepositoryUser)
            : base(RepositoryUser)
        {
            _repositoryUser = RepositoryUser;
        }

    }
}
