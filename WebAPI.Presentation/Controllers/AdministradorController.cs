using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO.DTO;
using WebAPI.Application.Interfaces;
using WebAPI.Util;
using WebAPI.Util.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;


        public AdministradorController(IApplicationServiceUser ApplicationServiceUser)
        {
            _applicationServiceUser = ApplicationServiceUser;
        }

        /// <summary>
        /// Método para adicionar Administradores
        /// </summary>
        /// <param name="admin">
        /// Parâmetro que deve ser passado para o método.
        /// </param>
        /// <returns>Retorna admin e token criados. </returns>
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO admin)
        {
            try
            {
                // conferir autenticação e se é admin
                if (admin == null)
                    return BadRequest("Parâmetro não encontrado.");

                if (_applicationServiceUser.LoginOrEmailExist(admin.Login, admin.Email))
                {
                    return BadRequest("Login ou Email já cadastrados anteriormente.");
                }
                admin.isAdmin = true;
                Password p = new Password();
                admin.Password = p.CreateSecurePassword(admin.Password);
                _applicationServiceUser.Add(admin);

                var token = TokenService.GenerateToken(admin);
                admin.Password = "";
                return Ok(new { user = admin, token = token });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para editar Administradores
        /// </summary>
        /// <param name="admin">
        /// Parâmetro que deve ser passado para o método.
        /// </param>
        /// <param name="id">
        /// Parâmetro que deve ser passado para o método pegar o Id do Administrador.
        /// </param>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDTO admin)
        {
            try
            {
                // conferir autenticação e se é admin
                if (_applicationServiceUser.GetById(id) == null)
                    return NotFound("Administrador não encontrado.");
                if (admin == null)
                    return BadRequest("Parâmetros não foram passados.");
                Password p = new Password();
                admin.Password = p.CreateSecurePassword(admin.Password);
                _applicationServiceUser.Update(admin);
                return Ok("Administrador Atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para Remover Administradores
        /// </summary>
        /// <param name="id">
        /// Parâmetro que deve ser passado para o método pegar o Id do Administrador.
        /// </param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // conferir autenticação e se é admin
                var admin = _applicationServiceUser.GetById(id);
                if (admin == null)
                    return NotFound("Administrador não encontrado.");
                admin.Active = false;
                _applicationServiceUser.Update(admin);
                return Ok("Administrador Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Método para obter a lista de usuários ativos não administradores
        /// </summary>
        /// <returns>
        /// Retorna a lista (total ou paginada) de usuários ativos não administradores
        /// </returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> ListarUsuarios([FromQuery] PaginationParams userParameters)
        {
            // conferir autenticação e se é admin
            if (userParameters.PageNumber != null && userParameters.PageSize != null)
                return Ok(_applicationServiceUser.GetUsers(userParameters));
            else
                return Ok(_applicationServiceUser.GetUsers(null));
        }
    }
}
