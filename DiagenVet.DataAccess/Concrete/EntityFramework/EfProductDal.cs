using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, DiagenVetContext>, IProductDal
{
    public EfProductDal(DiagenVetContext context) : base(context)
    {
    }
} 