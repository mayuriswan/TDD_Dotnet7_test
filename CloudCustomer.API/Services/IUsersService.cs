using CloudCustomer.API.Models;

namespace CloudCustomer.API.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetUsers();
    }
}
