using OnlineShop.Infrastructure.PersistenceBase;

namespace OnlineShop.Application.Base;

public abstract class BaseService
{
    protected IPersisterlayers _Persisterlayers;
    protected BaseService(IPersisterlayers persisterlayers)
    {
        _Persisterlayers = persisterlayers;
    }
}
