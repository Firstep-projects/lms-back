using DatabaseBroker.DataContext;
using Entity.Models;
using Entity.Models.Auth;

namespace DatabaseBroker.Repositories.Auth;

public class PermissionRepository(DataContext.DataContext dbContext)
    : RepositoryBase<Permission, long>(dbContext), IPermissionRepository;
