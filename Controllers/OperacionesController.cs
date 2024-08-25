using System.Collections.Generic;
using System.Linq;
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
            ViewData["Monto"] = null; 
            ViewData["Fecha"] = null;
            return View(); 
        }

        
        [HttpPost]
        public IActionResult Invertir(Operaciones operaciones, string[] Instrumentos)
        {
            List<Operaciones> listaOperaciones = new List<Operaciones>(); 
            decimal igvTotal = 0; 
            decimal montoAjustado; 

            
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

                
                if (operacion.Igv.HasValue)
                {
                    igvTotal += operacion.Igv.Value;
                }
            }

            
            if (operaciones.Monto.HasValue)
            {
                if (operaciones.Monto.Value <= 300)
                {
                    montoAjustado = operaciones.Monto.Value + 1; 
                }
                else
                {
                    montoAjustado = operaciones.Monto.Value + 3; 
                }
            }
            else
            {
                montoAjustado = 0; 
            }

            montoAjustado += igvTotal;

            
            ViewData["listaOperaciones"] = listaOperaciones;
            ViewData["Monto"] = montoAjustado;
            ViewData["Fecha"] = operaciones.Fecha;
            return View("Index"); 
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!"); 
        }
    }
}
