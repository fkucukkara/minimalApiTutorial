using Domain.Abstractions;

namespace Domain.Models;
public record Entity : IEntity, ICreateEntity, IUpdateEntity, ISoftDeleteEntity
{
    public int Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
}
