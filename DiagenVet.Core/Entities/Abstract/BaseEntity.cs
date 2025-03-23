using DiagenVet.Core.Entities;

namespace DiagenVet.Core.Entities.Abstract;

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
} 