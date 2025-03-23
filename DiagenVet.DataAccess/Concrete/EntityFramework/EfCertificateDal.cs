using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfCertificateDal : EfEntityRepositoryBase<Certificate, DiagenVetContext>, ICertificateDal
{
    public EfCertificateDal(DiagenVetContext context) : base(context)
    {
    }
} 