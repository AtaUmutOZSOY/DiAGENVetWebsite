using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiagenVet.DataAccess.Abstract;

public interface ILaboratoryDal : IEntityRepository<Laboratory>, IAsyncEntityRepository<Laboratory>
{
    DbContext Context { get; }
} 