using E_Learning.Models;
using E_Learning.Repositories.IReposatories;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<User> GetByEmail(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(context => context.Email == email);
            return user;
        }
    }
}
