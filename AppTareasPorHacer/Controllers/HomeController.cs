using System.Diagnostics;
using AppTareasPorHacer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTareasPorHacer.Controllers
{
    public class HomeController : Controller
    {

        private TareasContext _context = null!;
        public HomeController( TareasContext context) 
        {
            _context= context;
        }

        
        public IActionResult Index(string id="todo-todo-todo")
        {
            Filtros filtros = new Filtros(id);
            ViewBag.Filtros=filtros;
            ViewBag.Categorias = _context.Categoria.ToList();
            ViewBag.Estados = _context.Estado.ToList();
            ViewBag.FiltrosPlazo = Filtros.FiltrosPlazo();

            IQueryable<Tarea> consulta = _context.Tarea
                .Include(t => t.Categoria)
                .Include(t => t.Estado);

            if(filtros.TieneCategoria)
            {
                consulta = consulta.Where(t => t.CategoriaFK == filtros.Categoria);

            }

            if(filtros.TieneEstado)
            {
                consulta = consulta.Where(t => t.EstadoFK == filtros.Estado);
            }

            if(filtros.TienePlazo)
            {
                DateTime fechaActual = DateTime.Today;
                if(filtros.EsPasado == true)
                {
                    consulta= consulta.Where(t=>t.FechaTarea < fechaActual);
                }
                if(filtros.EsPresente == true)
                {
                    consulta = consulta.Where(t => t.FechaTarea == fechaActual);
                }

                if(filtros.EsFuturo == true)
                {
                    consulta = consulta.Where(t => t.FechaTarea > fechaActual);
                }


            }

            List<Tarea> lstTareas = consulta.ToList();

            return View(lstTareas);
        }


        [HttpGet]
        public IActionResult Agregar()
        {

            ViewBag.Categorias= _context.Categoria.ToList();
            ViewBag.Estados = _context.Estado.ToList();

            var tarea = new Tarea { EstadoFK = "pendiente" };
            return View(tarea);

        }

        [HttpPost]
        public IActionResult Agregar(Tarea objTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Tarea.Add(objTarea);
                _context.SaveChanges();
                return RedirectToAction("Index","Home");
            }

           ViewBag.Categorias = _context.Categoria.OrderBy(c=>c.CategoriaNombre).ToList();
           ViewBag.Estados = _context.Estado.OrderBy(e=>e.EstadoNombre).ToList();
           return View(objTarea);
        }

        [HttpPost]
        public IActionResult Filtrar (string[] filtros)
        {
            string segmentoid = string.Join("-",filtros);
            return RedirectToAction("Index", new {id=segmentoid});
        }

        [HttpPost]
        public IActionResult MarcarTareaRealizada([FromRoute]string id,Tarea objTarea)
        {
            objTarea = _context.Tarea.Find(objTarea.TareaId);
            if(objTarea != null)
            {
                objTarea.EstadoFK = "completada";
                _context.Update(objTarea);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { id });
        }


        [HttpPost]
        public IActionResult BorrarTarea(string id)
        {
            var consulta = _context.Tarea.Where(t => t.EstadoFK == "completada").ToList();

            foreach (var registro in consulta)
            {
                _context.Tarea.Remove(registro);
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { id});
        }
    }
}
