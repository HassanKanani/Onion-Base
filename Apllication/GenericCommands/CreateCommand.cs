
using Domain.Common;
using MediatR;

namespace Apllication.Create;
public class CreateCommand<TEntity> : IRequest<TEntity>
    where TEntity : BaseEntity
{
    public TEntity Entity { get; set; }

    public CreateCommand(TEntity entity)
    {
        Entity = entity;
    }
}