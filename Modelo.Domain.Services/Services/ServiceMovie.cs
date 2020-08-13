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
    public class ServiceMovie : ServiceBase<Movie>, IServiceMovie
    {
        public readonly IRepositoryMovie _repositoryMovie;

        public ServiceMovie(IRepositoryMovie RepositoryMovie)
            : base(RepositoryMovie)
        {
            _repositoryMovie = RepositoryMovie;
        }

    }
}
