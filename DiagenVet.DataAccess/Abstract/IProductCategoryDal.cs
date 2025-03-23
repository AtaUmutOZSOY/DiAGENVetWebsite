using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface IProductCategoryDal : IEntityRepository<ProductCategory>, IAsyncEntityRepository<ProductCategory>
{
} 