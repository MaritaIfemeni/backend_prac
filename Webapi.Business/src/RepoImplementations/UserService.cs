using AutoMapper;
using Webapi.Business.src.Dtos;
using Webapi.Business.src.Abstractions;
using Webapi.Domain.src.Entities;
using Webapi.Domain.src.RepoInterfaces;
using Webapi.Business.src.Shared;

namespace Webapi.Business.src.RepoImplementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {

        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)  // we can use the child IUserrepo here
        {
            _userRepo = userRepo;
        }

        public async Task<UserReadDto> UpdatePassword(string id, string newPassword)
        {
            var foundUser = await _userRepo.GetOneById(id);
            if (foundUser is null)
            {
                throw new Exception("Not Found"); // change this to a custom exception
            }
            return _mapper.Map<UserReadDto>(await _userRepo.UpdatePassword(foundUser, newPassword));
        }

        public override async Task<UserReadDto> CreateOne(UserCreateDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            PasswordService.HashPassword(dto.Password, out var hashedPassword, out var salt);
            entity.Password = hashedPassword;
            entity.Salt = salt;
            var created = await _userRepo.CreateOne(entity);
            return _mapper.Map<UserReadDto>(created);
        }
    }
}