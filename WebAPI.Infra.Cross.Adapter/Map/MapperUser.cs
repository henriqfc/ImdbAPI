using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.DTO.DTO;
using WebAPI.Infra.Cross.Adapter.Interfaces;

namespace WebAPI.Infra.Cross.Adapter.Map
{
    public class MapperUser : IMapperUser
    {
        #region properties

        List<UserDTO> UserDTOs = new List<UserDTO>();

        #endregion


        #region methods

        public User MapperToEntity(UserDTO UserDTO)
        {
            User User = new User
            {
                Id = UserDTO.Id,
                Active = UserDTO.Active,
                DateInsert = UserDTO.DateInsert,
                DateUpdate = UserDTO.DateUpdate,
                Email = UserDTO.Email,
                isAdmin = UserDTO.isAdmin,
                Login = UserDTO.Login,
                Name = UserDTO.Name,
                Password = UserDTO.Password
            };

            return User;

        }


        public IEnumerable<UserDTO> MapperListUsers(IEnumerable<User> Users)
        {
            foreach (var item in Users)
            {


                UserDTO UserDTO = new UserDTO
                {
                    Id = item.Id
                   ,
                    Active = item.Active,
                    Password = item.Password,
                    Name = item.Name,
                    Login = item.Login,
                    isAdmin = item.isAdmin,
                    Email = item.Email,
                    DateUpdate = item.DateUpdate,
                    DateInsert = item.DateInsert
                };



                UserDTOs.Add(UserDTO);

            }

            return UserDTOs;
        }

        public UserDTO MapperToDTO(User User)
        {

            UserDTO UserDTO = new UserDTO
            {
                Id = User.Id
                ,
                Active = User.Active,
                DateInsert = User.DateInsert,
                DateUpdate = User.DateUpdate,
                Email = User.Email,
                isAdmin = User.isAdmin,
                Login = User.Login,
                Name = User.Name,
                Password = User.Password

            };

            return UserDTO;

        }

        #endregion
    }
}
