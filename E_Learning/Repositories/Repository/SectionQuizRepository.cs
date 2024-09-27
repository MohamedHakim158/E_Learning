using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class SectionQuizRepository : ISectionQuizRepository
    {
        private readonly DbContext _context;

        public SectionQuizRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionQuiz>> GetAllAsync()
        {
            return await _context.Set<SectionQuiz>()
                .Include(q => q.QuizQuestions) // Include quiz questions
                .ToListAsync();
        }

        public async Task<SectionQuiz> GetByIdAsync(string id)
        {
            return await _context.Set<SectionQuiz>()
                .Include(q => q.QuizQuestions) // Include quiz questions
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task AddAsync(SectionQuiz sectionQuiz)
        {
            await _context.Set<SectionQuiz>().AddAsync(sectionQuiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SectionQuiz sectionQuiz)
        {
            _context.Set<SectionQuiz>().Update(sectionQuiz);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var sectionQuiz = await _context.Set<SectionQuiz>().FindAsync(id);
            if (sectionQuiz != null)
            {
                _context.Set<SectionQuiz>().Remove(sectionQuiz);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SectionQuiz>> GetQuizzesBySectionIdAsync(string sectionId)
        {
            return await _context.Set<SectionQuiz>()
                .Where(q => q.SectionId == sectionId)
                .Include(q => q.QuizQuestions) // Include quiz questions
                .ToListAsync();
        }
    }

}
