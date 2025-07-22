using DatabaseBroker.DataContext;
using Entity.Models;
using Entity.Models.Auth;

namespace DatabaseBroker.Repositories.Auth;

public class StructureRepository(DataContext.DataContext dbContext)
    : RepositoryBase<Structure, long>(dbContext), IStructureRepository;