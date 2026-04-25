
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CategoryEntity;

public class Category
{
    [Key]
    public int Key { get; set; }
    public string Name { get; set; }
}
