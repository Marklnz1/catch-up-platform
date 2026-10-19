namespace DefaultNamespace;

public interface IAuditableEntity
{
    DateTimeOffset? CreateAt { get; set; }
    DateTimeOffset? UpdateAt { get; set; }
}