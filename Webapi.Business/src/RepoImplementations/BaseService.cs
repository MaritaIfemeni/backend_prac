using AutoMapper;
using Webapi.Business.src.Abstractions;
using Webapi.Domain.src.Shared;
using Webapi.Domain.src.RepoInterfaces;

namespace Webapi.Business.src.RepoImplementations
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        private readonly IBaseRepo<T> _baseRepo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> baseRepo, IMapper mapper)  // constructor
        {
            _baseRepo = baseRepo;
            _mapper = mapper;
        }

        public virtual async Task<bool> DeleteOneById(string id)
        {
            var foundItem = await _baseRepo.GetOneById(id);
            if (foundItem is not null)
            {
                await _baseRepo.DeleteOneById(foundItem);
                return true;
            }
            return false; ///should it throw an exception instead?
        }

        public virtual async Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions)
        {
            return _mapper.Map<IEnumerable<TReadDto>>(await _baseRepo.GetAll(queryOptions));
        }

        public virtual async Task<TReadDto> GetOneById(string id)
        {
            return _mapper.Map<TReadDto>(await _baseRepo.GetOneById(id));
        }

        public virtual async Task<TReadDto> UpdateOneById(string id, TUpdateDto updated)
        {
            var foundItem = await _baseRepo.GetOneById(id);
            if (foundItem is null)
            {
                await _baseRepo.DeleteOneById(foundItem);
                throw new Exception("Not Found"); // change this to a custom exception
            }

            var updatedEntity = _baseRepo.UpdateOneById(foundItem, _mapper.Map<T>(updated));
            return _mapper.Map<TReadDto>(updatedEntity);
        }

        public virtual async Task<TReadDto> CreateOne(TCreateDto newEntity)
        {
            var createdEntity = await _baseRepo.CreateOne(_mapper.Map<T>(newEntity));
            return _mapper.Map<TReadDto>(createdEntity);
        }
    }
}