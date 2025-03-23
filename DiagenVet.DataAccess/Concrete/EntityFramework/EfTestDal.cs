using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfTestDal : EfEntityRepositoryBase<Test, DiagenVetContext>, ITestDal
{
    public EfTestDal(DiagenVetContext context) : base(context)
    {
    }
} 