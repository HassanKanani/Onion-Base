
using Apllication.Defination;
using Domain.Common;
using MediatR;

namespace Apllication.GetByKey;
public record GetByIdQuery<TEntity>(Guid Id) : IRequest<TEntity?>
    where TEntity : BaseEntity;

public class GetByIdQueryHandler<TEntity>
    : IRequestHandler<GetByIdQuery<TEntity>, TEntity?>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public GetByIdQueryHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<TEntity?> Handle(GetByIdQuery<TEntity> request, CancellationToken ct)
    {
        return await _repository.GetByIdAsync( ct,request.Id);
    }
}