using DiagenVet.Core.DataAccess;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Abstract;

public interface ISampleGuideDal : IEntityRepository<SampleGuide>, IAsyncEntityRepository<SampleGuide>
{
} 