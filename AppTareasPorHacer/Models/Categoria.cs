using System.ComponentModel.DataAnnotations;

namespace AppTareasPorHacer.Models
{
    public class Categoria
    {
        [Key]
        public string CategoriaId { get; set; }=string.Empty;

        public string CategoriaNombre { get; set; } = string.Empty;
    }
}
