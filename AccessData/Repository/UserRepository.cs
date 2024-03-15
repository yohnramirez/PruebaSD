using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AccessDataLayer.Repository
{
    /// <summary>
    /// Clase que gestiona las transacciones 
    /// de usuarios con la db
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Instancia del contexto con la db
        /// </summary>
        private readonly UserContext _context;

        /// <summary>
        /// Instancia del logger
        /// </summary>
        public readonly ILogger<UserRepository> logger;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public UserRepository(UserContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Método que obtiene los usuarios
        /// </summary>
        /// <returns>Retorna el listado de usuarios</returns>
        public async Task<IEnumerable<User>> Get()
        {
            return await this._context.Users.ToListAsync();
        }

        /// <summary>
        /// Método que guarda un usuario
        /// </summary>
        public async Task Post(User user)
        {
            try
            {
                this._context.Users.Add(user);
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al guardar interacción : {ex.Message}");
                return;
            }
        }

        /// <summary>
        /// Método que modifica un usuario
        /// </summary>
        public async Task Put(User user)
        {
            try
            {
                var userExists = await this.Search(user.UsuId);

                if (userExists == null) return;

                userExists.Nombre = user.Nombre;
                userExists.Apellido = user.Apellido;

                await this._context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                this.logger.LogError($"Error al modificar interacción : {ex.Message}");
                return;
            }
        }

        /// <summary>
        /// Método que busca un usuario por id
        /// </summary>
        public async Task<User?> Search(int userId)
        {
            return await this._context.Users.FindAsync(userId);
        }

        /// <summary>
        /// Método que elimina un usuario
        /// </summary>
        public async Task Delete(int userId)
        {
            try
            {
                var user = this._context.Users.Find(userId);

                if (user == null) return;

                this._context.Users.Remove(user);
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al modificar interacción : {ex.Message}");
                return;
            }
        }
    }
}
