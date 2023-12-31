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
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> FindByEmail(string email)
        {
            return await _users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> UpdatePassword(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public override async Task<User> CreateOne(User entity)
        {
            entity.UserRole = UserRole.User;
            return await base.CreateOne(entity);
        }
        public override async Task<User> UpdateOneById(User updatedEntity)
        {
            updatedEntity.UserRole = UserRole.User;
            return await base.UpdateOneById(updatedEntity);
        }

    }
}