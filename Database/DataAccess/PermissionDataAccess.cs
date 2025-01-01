using Database.Interfaces;
using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;

namespace Database.DataAccess;

internal class PermissionDataAccess(HybridCache hybridCache, EntityContext entityContext) : IPermissionDataAccess
{
    public async Task<IReadOnlyCollection<Permission>> GetRolePermissions(string roleKey)
    {
        var cacheKey = $"permissions:{roleKey}";
        return await hybridCache.GetOrCreateAsync(cacheKey, async _ => await GetPermissions(roleKey),
            new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromMinutes(20)
            });
    }

    private async Task<List<Permission>> GetPermissions(string roleKey)
    {
        var role = await entityContext.Roles.FirstAsync(x => x.Keyword == roleKey);
        var rolePermission = await entityContext.RolePermissions
            .Where(x => x.RoleId == role.Id)
            .Select(x => x.Permission)
            .ToListAsync();
        return rolePermission;
    }
}