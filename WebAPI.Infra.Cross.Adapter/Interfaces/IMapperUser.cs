using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;

namespace WebAPI.Infra.Cross.Adapter.Interfaces
{
    public interface IMapperUser
    {
        #region Mappers

        User MapperToEntity(UserDTO UserDTO);

        IEnumerable<UserDTO> MapperListUsers(IEnumerable<User> Users);

        UserDTO MapperToDTO(User User);

        #endregion
    }
}
