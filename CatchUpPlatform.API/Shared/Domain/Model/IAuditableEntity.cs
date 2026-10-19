namespace DefaultNamespace;

public class IAuditableEntity
{

    DateTimeOffset? CreateAt { get; set; }
    DateTimeOffset? UpdateAt { get; set; }
}