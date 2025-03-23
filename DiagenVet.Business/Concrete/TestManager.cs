using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class TestManager : ITestService
{
    private readonly ITestDal _testDal;

    public TestManager(ITestDal testDal)
    {
        _testDal = testDal;
    }

    public IResult Add(Test test)
    {
        _testDal.Add(test);
        return new SuccessResult(Messages.TestAdded);
    }

    public IResult Delete(Test test)
    {
        test.IsDeleted = true;
        test.IsActive = false;
        _testDal.Update(test);
        return new SuccessResult(Messages.TestDeleted);
    }

    public IResult HardDelete(Test test)
    {
        _testDal.Delete(test);
        return new SuccessResult(Messages.TestHardDeleted);
    }

    public IDataResult<List<Test>> GetAll()
    {
        return new SuccessDataResult<List<Test>>(_testDal.GetList().ToList());
    }

    public IDataResult<List<Test>> GetAllActive()
    {
        return new SuccessDataResult<List<Test>>(_testDal.GetList(t => t.IsActive && !t.IsDeleted).ToList());
    }

    public IDataResult<List<Test>> GetAllByLaboratory(int laboratoryId)
    {
        return new SuccessDataResult<List<Test>>(
            _testDal.GetList(t => t.LaboratoryId == laboratoryId && t.IsActive && !t.IsDeleted).ToList());
    }

    public IDataResult<Test> GetById(int id)
    {
        return new SuccessDataResult<Test>(_testDal.Get(t => t.Id == id));
    }

    public IResult Update(Test test)
    {
        test.UpdatedDate = DateTime.Now;
        _testDal.Update(test);
        return new SuccessResult(Messages.TestUpdated);
    }
} 