﻿using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CourseSectionRepository : ICourseSectionRepository
    {
        private readonly DbContext _context;

        public CourseSectionRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseSection>> GetAllAsync()
        {
            return await _context.Set<CourseSection>().ToListAsync();
        }

        public async Task<CourseSection> GetByIdAsync(string id)
        {
            return await _context.Set<CourseSection>().FindAsync(id);
        }

        public async Task AddAsync(CourseSection courseSection)
        {
            await _context.Set<CourseSection>().AddAsync(courseSection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseSection courseSection)
        {
            _context.Set<CourseSection>().Update(courseSection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var courseSection = await _context.Set<CourseSection>().FindAsync(id);
            if (courseSection != null)
            {
                _context.Set<CourseSection>().Remove(courseSection);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseSection>> GetSectionsByCourseIdAsync(string courseId)
        {
            return await _context.Set<CourseSection>()
                .Where(cs => cs.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseSection>> GetSectionsByOrderAsync(string courseId)
        {
            return await _context.Set<CourseSection>()
                .Where(cs => cs.CourseId == courseId)
                .ToListAsync();
        }
    }

}