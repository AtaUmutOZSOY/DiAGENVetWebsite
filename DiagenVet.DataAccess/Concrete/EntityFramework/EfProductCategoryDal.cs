using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfProductCategoryDal : EfEntityRepositoryBase<ProductCategory, DiagenVetContext>, IProductCategoryDal
{
    public EfProductCategoryDal(DiagenVetContext context) : base(context)
    {
    }
} 