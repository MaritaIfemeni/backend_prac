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

        public virtual async Task<bool> DeleteOneById(Guid id)
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
            var result = await _baseRepo.GetAll(queryOptions);
            return _mapper.Map<IEnumerable<TReadDto>>(result);
        }

        public virtual async Task<TReadDto> GetOneById(Guid id)
        {
            return _mapper.Map<TReadDto>(await _baseRepo.GetOneById(id));
        }

        public virtual async Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updated)
        {
            var entity = await _baseRepo.GetOneById(id);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found.");
            }

            _mapper.Map(updated, entity);

            var updatedEntity = await _baseRepo.UpdateOneById(entity);

            return _mapper.Map<TReadDto>(updatedEntity);
        }

        // public virtual async Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updated)  //this is not working?
        // {
        //     var foundItem = await _baseRepo.GetOneById(id);
        //     if (foundItem is null)
        //     {
        //         throw new Exception("Not Found"); // change this to a custom exception
        //     }
        //     return _mapper.Map<TReadDto>(await _baseRepo.UpdateOneById( _mapper.Map<T>(updated)));
        // }

        public virtual async Task<TReadDto> CreateOne(TCreateDto newEntity)
        {
            var createdEntity = await _baseRepo.CreateOne(_mapper.Map<T>(newEntity));
            return _mapper.Map<TReadDto>(createdEntity);
        }
    }
}