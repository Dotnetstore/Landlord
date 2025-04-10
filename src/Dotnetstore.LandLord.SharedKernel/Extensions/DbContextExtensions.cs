using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.LandLord.SharedKernel.Extensions;

public static class DbContextExtensions
{
    public static void DetachEntity<TEntity>(this DbContext context, TEntity entity) where TEntity : class
    {
        if (context.Entry(entity).State == EntityState.Detached)
        {
            return;
        }

        context.Entry(entity).State = EntityState.Detached;
    }
}