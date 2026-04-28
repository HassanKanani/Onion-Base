
using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public interface IEntity
{
}
public interface IEntity<TKey> : IEntity
{
    TKey Key { get; }
}
public abstract class BaseEntity<TKey> : IEntity
{
    [Key]
    public TKey Key { get; set; }
}
public abstract class BaseEntity : BaseEntity<int> { }