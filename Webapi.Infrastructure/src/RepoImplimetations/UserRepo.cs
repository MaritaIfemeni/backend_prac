using Microsoft.EntityFrameworkCore;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Infrastructure.src.Database;

namespace Webapi.Infrastructure.src.RepoImplimetations
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        private readonly DbSet<User> _users;
        private readonly DatabaseContex _context;

        public UserRepo(DatabaseContex dbContext) : base(dbContext)
        {
            _users = dbContext.Users;
            _context = dbContext;
        }

        public async Task<User> CreateAdmin(User user)
        {
            user.UserRole = UserRole.Admin;
            await _users.AddAsync(user);
            return user;
        }

        public async Task<User?> FindOneByEmail(string email)
        {
            return await _users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> UpdatePassword(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public override Task<User> CreateOne(User entity)
        {
            entity.UserRole = UserRole.User;
            return base.CreateOne(entity);
        }

        public Task<User> UpdatePassword(User user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}