
using Apllication.Defination;
using Domain.Common;
using MediatR;

namespace Apllication.Create;
// UpdateCommand.cs
public record UpdateCommand<TEntity>(TEntity Entity) : IRequest<bool>
    where TEntity : BaseEntity;

// UpdateCommandHandler.cs
public class UpdateCommandHandler<TEntity>
    : IRequestHandler<UpdateCommand<TEntity>, bool>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public UpdateCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateCommand<TEntity> request, CancellationToken ct)
    {
        await _repository.UpdateAsync(request.Entity, ct);
        return true;
    }
}