using AutoMapper;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;

namespace Webapi.Business.src.RepoImplementations
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {

        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)  // we can use the child IUserrepo here
        {
            _userRepo = userRepo;
        }

        public UserDto UpdatePassword(string id, string newPassword)
        {
            var foundUser = _userRepo.GetOneById(id);
            if (foundUser is null)
            {
                throw new Exception("Not Found"); // change this to a custom exception
            }
            return _mapper.Map<UserDto>(_userRepo.UpdatePassword(foundUser, newPassword));
        }
    }
}