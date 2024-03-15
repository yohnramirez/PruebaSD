using EntitiesLayer.Entities;

namespace BusinessLayer.UserLogic
{
    /// <summary>
    /// Definición de los métodos para la capa lógica/negocio
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        Task<IEnumerable<User>> GetAll();

        /// <summary>
        /// Método que guarda un usuario
        /// </summary>
        Task Post(User data);

        /// <summary>
        /// Método que actualiza un usuario
        /// </summary>
        Task Put(User user);

        /// <summary>
        /// Método que elimina un usuario
        /// </summary>
        Task Delete(int userId);
    }
}
