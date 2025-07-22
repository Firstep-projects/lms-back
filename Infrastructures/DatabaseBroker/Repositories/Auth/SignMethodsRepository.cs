using DatabaseBroker.DataContext;
using Entity.Models.Auth;

namespace DatabaseBroker.Repositories.Auth;

public class SignMethodsRepository(DataContext.DataContext dbContext)
    : RepositoryBase<SignMethod, long>(dbContext), ISignMethodsRepository;