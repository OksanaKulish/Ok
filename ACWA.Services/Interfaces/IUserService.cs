using ACWA.Domain.Models;
using ACWA.Services.Extensions;
using ACWA.Services.TransportModels.User.Request;
using ACWA.Services.TransportModels.User.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACWA.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserRequest model);
        Task DeleteUserAsync(Guid id);
        Task<List<UserResponse>> GetAllUsersAsync(int? skip = null, int? take = null, Expression<Func<User, bool>> wherePredicate = null, SortOptions<User> sortOptions = null);
        Task<UserResponse> GetUserByIdAsync(Guid id);
        Task<int> GetUsersCountAsync(Expression<Func<User, bool>> wherePredicate = null, SortOptions<User> sortOptions = null);
        Task<UserEditResponse> GetUserForEditByIdAsync(Guid id);
        Task UpdateUserAsync(UpdateUserRequest model);
    }
}