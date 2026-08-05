
using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using Modules.User.Application.IServices;
using Modules.User.Domain.IRepositories;

namespace Modules.User.Application.Services
{
    public class UserService(IUserRepository userRepository, IRoleService roleService, IUserRoleService userRoleService) : IUserService
    {
        public Task<Result> AddAsync(AddUserDTO dTO)
        {

            throw new NotImplementedException();
        }
    }
}


/*
#business logic for adding a new user:

-check if the input data is valid -> will be done at API level
-check if the user already exists in the database by email or phone number -> so will do it at business level
-generate a new user id -> will be done at business level
-get id of the role by its code -> will be done at business level
-add the user to the database -> will be done at business level
-add the user role to the database -> will be done at business level
-tell the school module to assign the user to the school -> will be done at business level

 */