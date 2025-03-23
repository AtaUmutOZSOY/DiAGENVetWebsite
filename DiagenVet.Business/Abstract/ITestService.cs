using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface ITestService
{
    IDataResult<Test> GetById(int id);
    IDataResult<List<Test>> GetAll();
    IDataResult<List<Test>> GetAllActive();
    IDataResult<List<Test>> GetAllByLaboratory(int laboratoryId);
    IResult Add(Test test);
    IResult Update(Test test);
    IResult Delete(Test test);
    IResult HardDelete(Test test);
} 