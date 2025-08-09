using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTareasPorHacer.Models
{
    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }

        [Required(ErrorMessage ="Ingrese una descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleccione una fecha")]
        public DateTime? FechaTarea { get; set; }

        [Required]
        public string CategoriaFK { get; set; }= string.Empty;

        [ValidateNever]
        [ForeignKey("CategoriaFK")]
        public Categoria Categoria { get; set; } = null!;

        [Required]
        public string EstadoFK { get; set; } = string.Empty;

        [ValidateNever]
        [ForeignKey("EstadoFK")]
        public Estado Estado { get; set; } = null!;

        public bool Overdue
        {
            get
            {
                return EstadoFK == "pendiente" && FechaTarea < DateTime.Today;
            }
        }

    }
}
