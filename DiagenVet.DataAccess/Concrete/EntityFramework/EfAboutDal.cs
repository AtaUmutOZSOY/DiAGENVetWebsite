using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfAboutDal : EfEntityRepositoryBase<About, DiagenVetContext>, IAboutDal
{
    public EfAboutDal(DiagenVetContext context) : base(context)
    {
    }
} 