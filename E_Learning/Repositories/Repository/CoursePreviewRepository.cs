﻿using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CoursePreviewRepository : ICoursePreviewRepository
    {
        private readonly DbContext _context;

        public CoursePreviewRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CoursePreview>> GetAllAsync()
        {
            return await _context.Set<CoursePreview>().ToListAsync();
        }

        public async Task<CoursePreview> GetByIdAsync(string id)
        {
            return await _context.Set<CoursePreview>().FindAsync(id);
        }

        public async Task AddAsync(CoursePreview coursePreview)
        {
            await _context.Set<CoursePreview>().AddAsync(coursePreview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CoursePreview coursePreview)
        {
            _context.Set<CoursePreview>().Update(coursePreview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var coursePreview = await _context.Set<CoursePreview>().FindAsync(id);
            if (coursePreview != null)
            {
                _context.Set<CoursePreview>().Remove(coursePreview);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CoursePreview>> GetPreviewsByCourseIdAsync(string courseId)
        {
            return await _context.Set<CoursePreview>()
                .Where(cp => cp.CourseId == courseId)
                .ToListAsync();
        }
    }

}