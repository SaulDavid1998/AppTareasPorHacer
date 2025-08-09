using System.ComponentModel.DataAnnotations;

namespace AppTareasPorHacer.Models
{
    public class Estado
    {
        [Key]
        public string EstadoId { get; set; } = string.Empty;

        public string EstadoNombre { get; set; } = string.Empty;

    }
}
