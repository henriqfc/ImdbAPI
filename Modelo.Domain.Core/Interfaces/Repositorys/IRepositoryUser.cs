using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Util;

namespace Modelo.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        IEnumerable<User> GetAll(bool isAdmin);
    }
}
