using DatabaseBroker.DataContext;
using Entity.Models.StaticFiles;

namespace DatabaseBroker.Repositories.StaticFiles;

public class StaticFileRepository(DataContext.DataContext dbContext)
    : RepositoryBase<StaticFile, long>(dbContext), IStaticFileRepository;