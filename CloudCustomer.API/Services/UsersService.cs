using CloudCustomer.API.Models;

namespace CloudCustomer.API.Services
{
    public class UsersService : IUsersService
    {
        

        Task<List<User>> IUsersService.GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
