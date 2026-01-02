using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorRegistroUsuarios.Data.Models
{
    [Table("UsuariosRegistradores")] // Asegúrate de que coincida con el nombre de la tabla en la base de datos
    public class UsuarioRegistrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El documento debe tener exactamente 12 caracteres")]
        [Display(Name = "Número de Documento")]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(100)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [StringLength(150)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La clave debe tener al menos 6 caracteres")]
        public string Clave { get; set; } = string.Empty;

        [Required]
        [Display(Name = "¿Trabaja?")]
        public bool Trabaja { get; set; } = true;

        [Required]
        [Display(Name = "¿Activo?")]
        public bool Activo { get; set; } = true;

        [Required]
        [StringLength(50)]
        [Display(Name = "Permiso")]
        public string Permiso { get; set; } = "Registrador";

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}