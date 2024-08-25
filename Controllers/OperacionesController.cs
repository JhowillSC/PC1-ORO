using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC1_ORO.Models;

namespace PC1_ORO.Controllers
{
    public class OperacionesController : Controller
    {
        private readonly ILogger<OperacionesController> _logger;

        public OperacionesController(ILogger<OperacionesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["listaOperaciones"] = new List<Operaciones>();
            return View();
        }

        [HttpPost]
        public IActionResult Invertir(Operaciones operaciones, string[] Instrumentos)
        {
            List<Operaciones> listaOperaciones = new List<Operaciones>();

            foreach (var instrumento in Instrumentos)
            {
                var operacion = new Operaciones
                {
                    Nombres = operaciones.Nombres,
                    Apellidos = operaciones.Apellidos,
                    Correo = operaciones.Correo,
                    Fecha = operaciones.Fecha,
                    Instrumento = instrumento,
                    Monto = operaciones.Monto
                };

                operacion.CalcularMonto();
                listaOperaciones.Add(operacion);
            }

            ViewData["listaOperaciones"] = listaOperaciones;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
