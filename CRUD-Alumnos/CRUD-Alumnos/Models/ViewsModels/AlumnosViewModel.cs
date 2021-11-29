using System.ComponentModel.DataAnnotations;

namespace CRUD_Alumnos.Models.ViewsModels
{
    public class AlumnosViewModel
    {
        [Required(ErrorMessage = "Los Nombres son requeridos")]
        [StringLength(100, ErrorMessage = "Los {0} debe de tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los Apellidos son requeridos")]
        [StringLength(100, ErrorMessage = "Los {0} debe de tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Range(minimum:18, maximum: 85 ,ErrorMessage = "La Edad debe ser entre 18 a 85 Anios")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El Sexo es requerido")]
        public string Sexo { get; set; }

        [Display(Name = "Fecha de Registro")]
        public System.DateTime Fecha_Registro { get; set; }
    }
}