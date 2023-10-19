﻿using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Data;
using ShiftsLogger.API.DTOs.Shift;
using ShiftsLogger.API.DTOs.Worker;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Services
{
    public class WorkersService
    {
        private readonly ApplicationDbContext _context;

        public WorkersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkerDTO>> GetAllWorkersAsync()
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



            return workers;
        }

        public async Task<WorkerDTO?> GetWorkerByIdAsync(int id)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null) return null;

            WorkerDTO workerDTO = new WorkerDTO
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
            };

            return workerDTO;
        }

        public async Task<Worker?> CreateWorkerAsync(AddWorkerDTO newWorker)
        {
            if (newWorker == null) return null;

            Worker worker = new Worker
            {
                FirstName = newWorker.FirstName,
                LastName = newWorker.LastName,

            };

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return worker;
        }

        public async Task<Worker?> UpdateWorkerAsync(int id, UpdateWorkerDTO updateWorker)
        {
            if (updateWorker == null) return null;
            if (id != updateWorker.Id) return null;

            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null) return null;

            worker.FirstName = updateWorker.FirstName;
            worker.LastName = updateWorker.LastName;

            _context.Workers.Update(worker);
            await _context.SaveChangesAsync();

            return worker;
        }

        public async Task<Worker?> DeleteWorkerAsync(int id)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
            if (worker == null) return null;

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return worker;
        }

        public async Task<List<ShiftDTO>> GetWorkerShiftsAsync(int id)
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

            return shifts;
        }
    }
}
