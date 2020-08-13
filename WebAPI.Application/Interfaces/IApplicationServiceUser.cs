using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Util;

namespace WebAPI.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        void Add(UserDTO obj);

        UserDTO GetById(int id);

        IEnumerable<UserDTO> GetAll();
        IEnumerable<UserDTO> GetUsers(PaginationParams userParams = null);
        bool LoginOrEmailExist(string login, string email);
        
        void Update(UserDTO obj);

        void Remove(UserDTO obj);

        void Dispose();

    }
}
