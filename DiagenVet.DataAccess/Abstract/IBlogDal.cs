using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface IBlogDal : IEntityRepository<Blog>, IAsyncEntityRepository<Blog>
{
} 