using E_Learning.Models;
using E_Learning.Repository.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly DbContext _context;

        public CertificateRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certificate>> GetAllAsync()
        {
            return await _context.Set<Certificate>().ToListAsync();
        }

        public async Task<Certificate> GetByIdAsync(string id)
        {
            return await _context.Set<Certificate>().FindAsync(id);
        }

        public async Task AddAsync(Certificate certificate)
        {
            await _context.Set<Certificate>().AddAsync(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Certificate certificate)
        {
            _context.Set<Certificate>().Update(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var certificate = await _context.Set<Certificate>().FindAsync(id);
            if (certificate != null)
            {
                _context.Set<Certificate>().Remove(certificate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Certificate>> GetCertificatesByUserIdAsync(string userId)
        {
            return await _context.Set<Certificate>()
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<Certificate?> GetCertificateByCourseAndUserAsync(string courseId, string userId)
        {
            return await _context.Set<Certificate>()
                .FirstOrDefaultAsync(c => c.CourseId == courseId && c.UserId == userId);
        }
    }

}
