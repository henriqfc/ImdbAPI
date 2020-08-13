using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DTO.DTO;
using WebAPI.Application.Interfaces;
using WebAPI.Util;
using WebAPI.Util.Token;

namespace WebAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;


        public UsuarioController(IApplicationServiceUser ApplicationServiceUser)
        {
            _applicationServiceUser = ApplicationServiceUser;
        }
        /// <summary>
        /// Método para adicionar Usuários
        /// </summary>
        /// <param name="user">
        /// Parâmetro que deve ser passado para o método.
        /// </param>
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO user)
        {
            try
            {
                if (user == null)
                    return NotFound();
                if (_applicationServiceUser.LoginOrEmailExist(user.Login, user.Email))
                {
                    return BadRequest("Login ou Email já cadastrados anteriormente.");
                }
                user.isAdmin = false;
                Password p = new Password();
                user.Password = p.CreateSecurePassword(user.Password);
                _applicationServiceUser.Add(user);

                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return Ok(new { user = user, token = token });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para editar Usuários
        /// </summary>
        /// <param name="user">
        /// Parâmetro que deve ser passado para o método.
        /// </param>
        /// <param name="id">
        /// Parâmetro que deve ser passado para o método pegar o Id do Usuário.
        /// </param>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDTO user)
        {
            try
            {
                // conferir autenticação e se é admin ou o proprio usuario alterando
                if (_applicationServiceUser.GetById(id) == null)
                    return NotFound("Usuário não encontrado.");
                if (user == null)
                    return BadRequest("Parâmetros não foram passados.");
                user.isAdmin = false;
                Password p = new Password();
                user.Password = p.CreateSecurePassword(user.Password);
                _applicationServiceUser.Update(user);
                return Ok("Usuário Atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método para Remover Usuários
        /// </summary>
        /// <param name="id">
        /// Parâmetro que deve ser passado para o método pegar o Id do Usuário.
        /// </param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // conferir autenticação e se é admin ou o proprio usuario alterando
                var user = _applicationServiceUser.GetById(id);
                if (user == null)
                    return NotFound();
                user.Active = false;
                _applicationServiceUser.Update(user);
                return Ok("Usuário Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
