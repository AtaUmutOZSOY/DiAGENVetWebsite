using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Concrete.EntityFramework.Contexts;
using DiagenVet.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfLaboratoryDal : EfEntityRepositoryBase<Laboratory, DiagenVetContext>, ILaboratoryDal
{
    private readonly DiagenVetContext _context;

    public EfLaboratoryDal(DiagenVetContext context) : base(context)
    {
        _context = context;
    }

    public DbContext Context => _context;
} 