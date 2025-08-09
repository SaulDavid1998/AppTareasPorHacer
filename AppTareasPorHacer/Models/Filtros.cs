namespace AppTareasPorHacer.Models
{
    public class Filtros
    {

        public Filtros(string filtro)
        {
            //if (string.IsNullOrEmpty(filtro))
            //{
            //    FilstrosString = "todo-todo-todo";
            //}
            //else
            //{
            //    FilstrosString = filtro;
            //}
            FilstrosString = filtro;
            string[] arrayFiltros = FilstrosString.Split('-');
            Categoria = arrayFiltros[0];
            Estado = arrayFiltros[1];
            Plazo = arrayFiltros[2];
        }


        public string FilstrosString { get; }

        public string Categoria { get; }

        public string Estado { get; }

        public string Plazo { get; }

        public bool TieneCategoria
        {
            get
            {
                return Categoria.ToLower() != "todo";
            }
        }

        public bool TieneEstado
        {
            get
            {
                return Estado.ToLower() != "todo";
            }
        }

        public bool TienePlazo
        {
            get
            {
                return Plazo.ToLower() != "todo";
            }
        }

        public static Dictionary<string, string> FiltrosPlazo()
        {
            return new Dictionary<string, string>
            {
                { "pasado", "Pasado" },
                { "presente", "Presente" },
                { "futuro", "Futuro" }
            };
        }

        public bool EsPasado
        {
            get
            {
                return Plazo.ToLower() == "pasado";
            }
        }

        public bool EsPresente
        {
            get
            {
                return Plazo.ToLower() == "presente";
            }
        }

        public bool EsFuturo
        {
            get
            {
                return Plazo.ToLower() == "futuro";
            }
        }



    }
}
