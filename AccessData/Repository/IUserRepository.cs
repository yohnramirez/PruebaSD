using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLayer.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        Task<IEnumerable<User>> Get();

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

        /// <summary>
        /// Método que busca un usuario por id
        /// </summary>
        Task<User?> Search(int userId);
    }
}
