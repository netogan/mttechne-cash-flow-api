using Cash.Flow.Api.Data.Context;
using Cash.Flow.Api.Data.Repositories.Interfaces;
using Cash.Flow.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cash.Flow.Api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly CashFlowContext _context;

        public UserRepository(CashFlowContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int id) => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        public IEnumerable<User> GetUsers() => _context.Users;

        public async Task<User> AddUser(User user) 
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await GetUser(user.Id);
        }

        public async Task<User> UpdateUser(User user)
        {
            var userExist = await GetUser(user.Id);
            
            if (userExist != null) 
            {
                _context.Entry(userExist).CurrentValues.SetValues(user);
            }
            else
            {
                await AddUser(user);
            }

            return await GetUser(user.Id);
        }

        public async Task DeleteUser(int id) 
        { 
            var userExist = await GetUser(id);

            if (userExist != null)
            { 
                _context.Users.Remove(userExist); 
                await _context.SaveChangesAsync();
            }
        }
    }
}
