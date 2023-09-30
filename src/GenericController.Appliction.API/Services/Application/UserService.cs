using GenericController.Appliction.API.Context;
using GenericController.Appliction.API.Models;
using GenericController.Appliction.API.Services.Interfaces;

namespace GenericController.Appliction.API.Services.Application
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(SQLServerContext context) : base(context)
        {
            
        }
    }
}
