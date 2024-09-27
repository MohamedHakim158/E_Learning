﻿using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class InstructorWithdrawRepository : IInstructorWithdrawRepository
    {
        private readonly DbContext _context;

        public InstructorWithdrawRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstructorWithdraw>> GetAllAsync()
        {
            return await _context.Set<InstructorWithdraw>().ToListAsync();
        }

        public async Task<InstructorWithdraw> GetByIdAsync(string id)
        {
            return await _context.Set<InstructorWithdraw>().FindAsync(id);
        }

        public async Task AddAsync(InstructorWithdraw instructorWithdraw)
        {
            await _context.Set<InstructorWithdraw>().AddAsync(instructorWithdraw);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InstructorWithdraw instructorWithdraw)
        {
            _context.Set<InstructorWithdraw>().Update(instructorWithdraw);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var instructorWithdraw = await _context.Set<InstructorWithdraw>().FindAsync(id);
            if (instructorWithdraw != null)
            {
                _context.Set<InstructorWithdraw>().Remove(instructorWithdraw);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InstructorWithdraw>> GetWithdrawalsByUserIdAsync(string userId)
        {
            return await _context.Set<InstructorWithdraw>()
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }
    }

}
