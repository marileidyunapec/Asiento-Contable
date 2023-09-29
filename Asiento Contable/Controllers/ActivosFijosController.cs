using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Asiento_Contable.Models;
using System.Xml.Serialization;
using System.Xml;

namespace Asiento_Contable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly AsientoContableContext _context;

        public DatosController(AsientoContableContext context)
        {
            _context = context;
        }

        [HttpGet("generarXml")]
        public async Task<IActionResult> GenerarXml()
        {
            try
            {
                var activos = await _context.ActivosFijos.ToListAsync();

                if (activos == null || !activos.Any())
                {
                    return NotFound("No se encontraron datos para generar el XML.");
                }

                var downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                var fileName = "activosfijos.xml";

                var filePath = Path.Combine(downloadsFolder, fileName);

                using (var xmlWriter = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
                {

                    var xmlSerializer = new XmlSerializer(typeof(List<ActivosFijos>),
                    new XmlRootAttribute("AsientosContables"));
                    xmlSerializer.Serialize(xmlWriter, activos);
                }

                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/xml", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("obtenerAsientos")]
        public IActionResult ObtenerAsientos()
        {
            try
            {
               
                var asientos = _context.ActivosFijos.ToList(); 

                if (asientos == null || !asientos.Any())
                {
                    return NotFound("No se encontraron asientos contables.");
                }

                return Ok(asientos); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPost("nuevoAsiento")]
        public async Task<IActionResult> NuevoAsiento(ActivosFijos datosEntrada)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nuevoAsiento = new ActivosFijos
                    {
                        Descripcion = datosEntrada.Descripcion,
                        FechaAsiento = datosEntrada.FechaAsiento,
                        CuentaContable = datosEntrada.CuentaContable,
                        TipoMovimiento = datosEntrada.TipoMovimiento,
                        MontoMovimiento = datosEntrada.MontoMovimiento
                    };

                    _context.ActivosFijos.Add(nuevoAsiento);
                    await _context.SaveChangesAsync();

                    // Devuelve una respuesta exitosa
                    return Ok("Asiento contable creado exitosamente.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
