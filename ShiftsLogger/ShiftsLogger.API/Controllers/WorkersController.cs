using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Data;
using ShiftsLogger.API.DTOs.Shift;
using ShiftsLogger.API.DTOs.Worker;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkers()
        {
            var workers = await _context
                .Workers
                .Select(w => new WorkerDTO
                {
                    Id = w.Id,
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                })
                .ToListAsync();



            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkerById(int id)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null) return NotFound();

            WorkerDTO workerDTO = new WorkerDTO
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
            };

            return Ok(workerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker(AddWorkerDTO newWorker)
        {
            if (newWorker == null) return BadRequest();

            Worker worker = new Worker
            {
                FirstName = newWorker.FirstName,
                LastName = newWorker.LastName,

            };

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkerById), new { Id = worker.Id }, worker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkerById(int id, UpdateWorkerDTO updateWorker)
        {
            if (updateWorker == null) return BadRequest();
            if (id != updateWorker.Id) return BadRequest();

            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null) return NotFound();

            worker.FirstName = updateWorker.FirstName;
            worker.LastName = updateWorker.LastName;

            _context.Workers.Update(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkerById(int id)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null) return NotFound();

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        // Get all shifts by worker id
        [HttpGet("{id}/shifts")]
        public async Task<IActionResult> GetWorkerShiftsById(int id)
        {
            var shifts = await _context
                .Shifts
                .Include(s => s.Worker)
                .Select(s => new ShiftDTO
                {
                    WorkerId = s.WorkerId,
                    Start = s.Start,
                    End = s.End,
                })
                .Where(s => s.WorkerId == id)
                .ToListAsync();

            return Ok(shifts);
        }

    }
}
