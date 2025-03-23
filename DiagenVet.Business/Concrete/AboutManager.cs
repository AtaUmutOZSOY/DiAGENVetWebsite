using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public IResult Add(About about)
    {
        _aboutDal.Add(about);
        return new SuccessResult(Messages.AboutAdded);
    }

    public IResult Delete(About about)
    {
        about.IsDeleted = true;
        about.IsActive = false;
        _aboutDal.Update(about);
        return new SuccessResult(Messages.AboutDeleted);
    }

    public IResult HardDelete(About about)
    {
        _aboutDal.Delete(about);
        return new SuccessResult(Messages.AboutHardDeleted);
    }

    public IDataResult<List<About>> GetAll()
    {
        return new SuccessDataResult<List<About>>(_aboutDal.GetList().ToList());
    }

    public IDataResult<List<About>> GetAllActive()
    {
        return new SuccessDataResult<List<About>>(_aboutDal.GetList(a => a.IsActive && !a.IsDeleted).ToList());
    }

    public IDataResult<About> GetById(int id)
    {
        return new SuccessDataResult<About>(_aboutDal.Get(a => a.Id == id));
    }

    public IResult Update(About about)
    {
        about.UpdatedDate = DateTime.Now;
        _aboutDal.Update(about);
        return new SuccessResult(Messages.AboutUpdated);
    }
} 