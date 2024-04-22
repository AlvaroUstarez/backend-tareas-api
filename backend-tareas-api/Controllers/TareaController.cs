using backend_tareas_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_tareas_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private static List<Tarea> listaTareas = new List<Tarea>
    {
        new Tarea { Id = 1, Nombre = "Terminar el informe", Estado = false },
        new Tarea { Id = 2, Nombre = "Preparar la presentación", Estado = false }
    };

        [HttpGet]
        public Task<IActionResult> Get()
        {
            try
            {
                return Task.FromResult<IActionResult>(Ok(listaTareas));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
            }
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                tarea.Id = listaTareas.Count + 1;
                listaTareas.Add(tarea);
                return Task.FromResult<IActionResult>(CreatedAtAction(nameof(Get), listaTareas));
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            try
            {
                var index = listaTareas.FindIndex(t => t.Id == id);
                if (index < 0)
                {
                    return Task.FromResult<IActionResult>(NotFound());
                }
                if (id != tarea.Id)
                {
                    return Task.FromResult<IActionResult>(BadRequest());
                }
                listaTareas[index].Estado = !tarea.Estado;
                return Task.FromResult<IActionResult>(NoContent());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = listaTareas.FirstOrDefault(t => t.Id == id);
                if (tarea == null)
                {
                    return Task.FromResult<IActionResult>(NotFound());
                }

                listaTareas.Remove(tarea);
                return Task.FromResult<IActionResult>(NoContent());
            }
            catch (Exception ex)
            {
                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
            }
        }

    }
}
