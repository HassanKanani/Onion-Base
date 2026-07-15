
using Apllication.Defination;
using Domain.Common;
using MediatR;

namespace Apllication.GetByKey;
public record GetAllQuery<TEntity>() : IRequest<IReadOnlyList<TEntity>>
    where TEntity : BaseEntity;

public class GetAllQueryHandler<TEntity>
    : IRequestHandler<GetAllQuery<TEntity>, IReadOnlyList<TEntity>>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public GetAllQueryHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<TEntity>> Handle(GetAllQuery<TEntity> request, CancellationToken ct)
    {
        return await _repository.GetAllAsync(ct);
    }
}