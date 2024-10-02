using E_Learning.Models;

namespace E_Learning.Repositories.IReposatories
{
    public interface IUserRepository
    {
        public Task<User> GetByEmail(string email);
    }
}
