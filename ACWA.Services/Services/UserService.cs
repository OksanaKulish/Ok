using ACWA.Domain;
using ACWA.Domain.Models;
using ACWA.Services.Extensions;
using ACWA.Services.Interfaces;
using ACWA.Services.TransportModels.User.Request;
using ACWA.Services.TransportModels.User.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACWA.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ACWAContext _context;

        public UserService(ACWAContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(AddUserRequest model)
        {
            await _context.Users.AddAsync(model.ToUser());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserResponse>> GetAllUsersAsync(int? skip = null, int? take = null, Expression<Func<User, bool>> wherePredicate = null, SortOptions<User> sortOptions = null)
        {
            if (sortOptions == null)
            {
                sortOptions = new SortOptions<User>(x => x.FullNameNormalized, SortTypes.ASC);
            }

            IQueryable<User> query = _context.Users;
            query = wherePredicate != null ? query.Where(wherePredicate) : query;
            query = sortOptions.SortType == SortTypes.ASC ? query.OrderBy(sortOptions.Predicate) : query.OrderByDescending(sortOptions.Predicate);
            query = query.Skip(skip.GetValueOrDefault());
            query = take != null ? query.Take(take.Value) : query;

            List<User> users = await query.ToListAsync();
            return users.ToUserResponseList();
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            return user.ToUserResponse();
        }

        public async Task<UserEditResponse> GetUserForEditByIdAsync(Guid id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            return user.ToUserEditResponse();
        }

        public async Task<int> GetUsersCountAsync(Expression<Func<User, bool>> wherePredicate = null, SortOptions<User> sortOptions = null)
        {
            if (sortOptions == null)
            {
                sortOptions = new SortOptions<User>(x => x.FullNameNormalized, SortTypes.ASC);
            }

            IQueryable<User> query = _context.Users;
            query = wherePredicate != null ? query.Where(wherePredicate) : query;
            query = sortOptions.Predicate == null ? query :
                sortOptions.SortType == SortTypes.ASC ? query.OrderBy(sortOptions.Predicate) : query.OrderByDescending(sortOptions.Predicate);

            return await query.CountAsync();
        }

        public async Task UpdateUserAsync(UpdateUserRequest model)
        {
            _context.Entry(model.ToUser()).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
