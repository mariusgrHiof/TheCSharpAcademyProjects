using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Data;
using ShiftsLogger.API.DTOs.Shift;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsLoggerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShiftsLoggerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShifts()
        {
            var shifts = await _context.Shifts

                .Select(s => new ShiftDTO
                {
                    Start = s.Start,
                    End = s.End,

                    WorkerId = s.WorkerId
                })
                .ToListAsync();

            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftById(int id)
        {
            var shift = await _context
                .Shifts

                .FirstOrDefaultAsync(s => s.Id == id);

            if (shift == null) return NotFound();

            // Map from Shift => ShiftDTO
            ShiftDTO shiftDTO = new ShiftDTO
            {
                Start = shift.Start,
                End = shift.End,
                WorkerId = shift.WorkerId
            };


            return Ok(shiftDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift(AddShiftDTO newShift)
        {
            if (newShift == null) return BadRequest();

            // Map from AddShiftDTO => Shift
            Shift shift = new Shift
            {
                Start = newShift.Start,
                End = newShift.End,
                WorkerId = newShift.WorkerId
            };

            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShiftById), new { Id = shift.Id }, shift);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShift(int id, UpdateShiftDTO updateShift)
        {

            if (updateShift == null) return BadRequest();
            if (id != updateShift.Id) return BadRequest();

            var shift = await _context
                .Shifts

                .FirstOrDefaultAsync(s => s.Id == id);

            if (shift == null) return NotFound();

            shift.Start = updateShift.Start;
            shift.End = updateShift.End;
            shift.WorkerId = updateShift.WorkerId;

            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();

            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShiftById(int id)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.Id == id);

            if (shift == null) return NotFound();

            _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
