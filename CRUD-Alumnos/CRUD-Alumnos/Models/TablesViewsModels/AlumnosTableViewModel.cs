using System.ComponentModel.DataAnnotations;

namespace CRUD_Alumnos.Models.TablesViewsModels
{
    public class AlumnosTableViewModel
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        [Display(Name = "Fecha de Registro")]
        public System.DateTime Fecha_Registro { get; set; }
    }
}