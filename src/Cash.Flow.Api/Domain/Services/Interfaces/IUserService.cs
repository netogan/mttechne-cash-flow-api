using Cash.Flow.Api.Domain.Models;

namespace Cash.Flow.Api.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        IEnumerable<User> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
