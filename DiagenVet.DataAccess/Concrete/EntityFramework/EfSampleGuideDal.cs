using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfSampleGuideDal : EfEntityRepositoryBase<SampleGuide, DiagenVetContext>, ISampleGuideDal
{
    public EfSampleGuideDal(DiagenVetContext context) : base(context)
    {
    }
} 