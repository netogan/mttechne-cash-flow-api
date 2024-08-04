using Cash.Flow.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cash.Flow.Api.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        IEnumerable<User> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
