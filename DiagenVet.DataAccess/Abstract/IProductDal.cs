using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>, IAsyncEntityRepository<Product>
{
} 