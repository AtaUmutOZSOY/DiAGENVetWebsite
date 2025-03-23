using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface IAboutDal : IEntityRepository<About>, IAsyncEntityRepository<About>
{
} 