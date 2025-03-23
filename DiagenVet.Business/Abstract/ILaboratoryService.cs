using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface ILaboratoryService
{
    IDataResult<Laboratory> GetById(int id);
    IDataResult<List<Laboratory>> GetAll();
    IDataResult<List<Laboratory>> GetAllActive();
    IDataResult<List<Laboratory>> GetAllWithTests();
    IResult Add(Laboratory laboratory);
    IResult Update(Laboratory laboratory);
    IResult Delete(Laboratory laboratory);
    IResult HardDelete(Laboratory laboratory);
} 