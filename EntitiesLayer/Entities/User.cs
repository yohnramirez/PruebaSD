using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLayer.Entities
{
    /// <summary>
    /// Entidad usuario
    /// </summary>
    public class User
    {
        /// <summary>
        /// Define la primary key de la tabla
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuId { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        [Required, StringLength(100)]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        [Required, StringLength(100)]
        public string Apellido { get; set; }
    }
}
