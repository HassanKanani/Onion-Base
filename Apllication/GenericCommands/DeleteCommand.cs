
using Apllication.Defination;
using Domain.Common;
using MediatR;

namespace Apllication.Create;
// DeleteCommand.cs
public record DeleteCommand<TEntity>(Guid Id) : IRequest<bool>
    where TEntity : BaseEntity;

// DeleteCommandHandler.cs
public class DeleteCommandHandler<TEntity>
    : IRequestHandler<DeleteCommand<TEntity>, bool>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;

    public DeleteCommandHandler(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCommand<TEntity> request, CancellationToken ct)
    {
       var en=await _repository.GetByIdAsync(ct, request.Id);
        if (en != null) {
            throw new Exception("not found");
        }
        await _repository.DeleteAsync(en, ct);
        return true;
    }
}