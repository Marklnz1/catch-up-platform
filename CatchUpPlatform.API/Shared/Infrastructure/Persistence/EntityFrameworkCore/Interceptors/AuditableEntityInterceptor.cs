using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;

public sealed class AuditableEntityInterceptor:SaveChangesInterceptor
{
    private static void ApplyAuditTimeStamps(DbContext? context)
    {
        if (context is null) return;
        var now = DateTimeOffset.UtcNow;
        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            if(entry.State is EntityState.Added or  EntityState.Modified) 
            {
                entry.Entity.UpdateAt = now;
            }

            if (entry.State is EntityState.Added)
            {
                entry.Entity.CreateAt ??= now;
            }
        }
    }
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplyAuditTimeStamps(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditTimeStamps(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}