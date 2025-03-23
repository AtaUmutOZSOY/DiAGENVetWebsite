using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface ICertificateDal : IEntityRepository<Certificate>, IAsyncEntityRepository<Certificate>
{
} 