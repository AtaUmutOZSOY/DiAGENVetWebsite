using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface ITestDal : IEntityRepository<Test>, IAsyncEntityRepository<Test>
{
} 