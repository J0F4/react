using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tareas.Domain.Entities;
using Tareas.Domain.Interfaces;

namespace Tareas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;

        public TareasController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTareasAsync()
        {
            return Ok(await _tareaRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddTareaAsync(Tarea tarea)
        {
            return Ok(await _tareaRepository.Addyasync(tarea));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTareaAsync(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            if (!await _tareaRepository.GetAnyAsync(id)) return NotFound();

            return Ok(await _tareaRepository.DeleteAnyAsync(id));
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdatesTareaAsync(Guid id , Tarea tarea)
        {
            if (id == Guid.Empty) return BadRequest();

            if (!await _tareaRepository.GetAnyAsync(id)) return NotFound();

            return Ok(await _tareaRepository.UpdateAsync(tarea , id));  
        }
    }
}
