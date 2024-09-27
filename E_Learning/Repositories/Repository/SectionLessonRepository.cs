using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class SectionLessonRepository : ISectionLessonRepository
    {
        private readonly DbContext _context;

        public SectionLessonRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionLessons>> GetAllAsync()
        {
            return await _context.Set<SectionLessons>().ToListAsync();
        }

        public async Task<SectionLessons> GetByIdAsync(string id)
        {
            return await _context.Set<SectionLessons>().FindAsync(id);
        }

        public async Task AddAsync(SectionLessons sectionLesson)
        {
            await _context.Set<SectionLessons>().AddAsync(sectionLesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SectionLessons sectionLesson)
        {
            _context.Set<SectionLessons>().Update(sectionLesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var sectionLesson = await _context.Set<SectionLessons>().FindAsync(id);
            if (sectionLesson != null)
            {
                _context.Set<SectionLessons>().Remove(sectionLesson);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SectionLessons>> GetLessonsBySectionIdAsync(string sectionId)
        {
            return await _context.Set<SectionLessons>()
                .Where(lesson => lesson.SectionId == sectionId)
                .ToListAsync();
        }
    }

}
