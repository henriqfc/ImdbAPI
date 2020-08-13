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
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapperUser _mapperUser;

        public ApplicationServiceUser(IServiceUser ServiceUser
                                                 , IMapperUser MapperUser)

        {
            _serviceUser = ServiceUser;
            _mapperUser = MapperUser;
        }


        public void Add(UserDTO obj)
        {
            var objUser = _mapperUser.MapperToEntity(obj);
            _serviceUser.Add(objUser);
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var objProdutos = _serviceUser.GetAll();
            return _mapperUser.MapperListUsers(objProdutos);
        }

        public UserDTO GetById(int id)
        {
            var objUser = _serviceUser.GetById(id);
            return _mapperUser.MapperToDTO(objUser);
        }

        public IEnumerable<UserDTO> GetUsers(PaginationParams userParams = null)
        {
            var objProdutos = _serviceUser.GetAll().Where(u => u.isAdmin == false && u.Active).OrderBy(on => on.Name).ToList();
            if (userParams != null)
                objProdutos = objProdutos.Skip((userParams.PageNumber.Value - 1) * userParams.PageSize.Value).Take(userParams.PageSize.Value).ToList();
            return _mapperUser.MapperListUsers(objProdutos);
        }

        public bool LoginOrEmailExist(string login, string email)
        {
            return _serviceUser.GetAll().Any(u => u.Login == login || u.Email == email);
        }

        public void Remove(UserDTO obj)
        {
            var objUser = _mapperUser.MapperToEntity(obj);
            _serviceUser.Remove(objUser);
        }

        public void Update(UserDTO obj)
        {
            var objUser = _mapperUser.MapperToEntity(obj);
            _serviceUser.Update(objUser);
        }
        
    }
}
