using BusinessLayer.UserLogic;
using EntitiesLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    /// <summary>
    /// Servicio encargado ed administrad la información de los usuarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Instancia de la capa lógica/negocio
        /// </summary>
        public readonly IUserLogic _logic;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }

        /// <summary>
        /// Método que retorna todos los usuarios
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await this._logic.GetAll();

            return Ok(response);
        }

        /// <summary>
        /// Método que guarda un usuario
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            if (user == null) return BadRequest("Datos no válidos");

            await this._logic.Post(user);

            return Ok();
        }

        /// <summary>
        /// Método que actualiza un usuario
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (user == null) return BadRequest("Datos no válidos");

            await this._logic.Put(user);

            return Ok();
        }

        /// <summary>
        /// Método que elimina un usuario
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (userId < 1) return BadRequest("Id de usuario no válido");

            await this._logic.Delete(userId);

            return Ok();
        }
    }
}
