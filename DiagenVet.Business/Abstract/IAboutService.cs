using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface IAboutService
{
    IDataResult<About> GetById(int id);
    IDataResult<List<About>> GetAll();
    IDataResult<List<About>> GetAllActive();
    IResult Add(About about);
    IResult Update(About about);
    IResult Delete(About about);
    IResult HardDelete(About about);
} 