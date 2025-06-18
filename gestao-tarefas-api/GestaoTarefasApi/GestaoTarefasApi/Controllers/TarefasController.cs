using GestaoTarefasApi.Data;
using GestaoTarefasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
            => await _context.Tarefas.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            return tarefa is null? NotFound() : tarefa;
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id) return BadRequest();

            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa is null) return NotFound();

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
