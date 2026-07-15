using Apllication.Defination;
using Domain.Common;
using MediatR;

namespace Apllication.Create;
public class CreateCommandHandler<TEntity> : IRequestHandler<CreateCommand<TEntity>, TEntity> where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public CreateCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<TEntity> Handle(CreateCommand<TEntity> request, CancellationToken ct)
    {
        return await _repository.AddAsync(request.Entity, ct);
    }
}
