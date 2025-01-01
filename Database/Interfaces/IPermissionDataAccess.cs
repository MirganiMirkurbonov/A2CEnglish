using Database.Tables;

namespace Database.Interfaces;

public interface IPermissionDataAccess
{
    Task<IReadOnlyCollection<Permission>> GetRolePermissions(string roleKey);
}