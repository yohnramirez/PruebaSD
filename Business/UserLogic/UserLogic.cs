using AccessDataLayer.Repository;
using EntitiesLayer.Entities;

namespace BusinessLayer.UserLogic
{
    /// <summary>
    /// Clase que define la capa de negocio
    /// </summary>
    public class UserLogic : IUserLogic
    {
        /// <summary>
        /// Instancia del repositorio de usuarios
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserLogic(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await this._repository.Get();

            return result;
        }

        /// <summary>
        /// Método que guarda un usuario
        /// </summary>
        public async Task Post(User data)
        {
            if (data == null) return;

            await this._repository.Post(data);
        }

        /// <summary>
        /// Método que actualiza un usuario
        /// </summary>
        public async Task Put(User data)
        {
            var user = await this._repository.Search(data.UsuId);

            if (user == null) return;

            await _repository.Put(data);
        }

        /// <summary>
        /// Método que elimina un usuario
        /// </summary>
        public async Task Delete(int userId)
        {
            if (userId < 1) return;

            await this._repository.Delete(userId);
        }
    }
}
