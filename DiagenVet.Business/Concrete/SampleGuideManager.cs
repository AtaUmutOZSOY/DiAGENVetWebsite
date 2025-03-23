using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class SampleGuideManager : ISampleGuideService
{
    private readonly ISampleGuideDal _sampleGuideDal;

    public SampleGuideManager(ISampleGuideDal sampleGuideDal)
    {
        _sampleGuideDal = sampleGuideDal;
    }

    public IResult Add(SampleGuide sampleGuide)
    {
        _sampleGuideDal.Add(sampleGuide);
        return new SuccessResult(Messages.SampleGuideAdded);
    }

    public IResult Delete(SampleGuide sampleGuide)
    {
        sampleGuide.IsDeleted = true;
        sampleGuide.IsActive = false;
        _sampleGuideDal.Update(sampleGuide);
        return new SuccessResult(Messages.SampleGuideDeleted);
    }

    public IResult HardDelete(SampleGuide sampleGuide)
    {
        _sampleGuideDal.Delete(sampleGuide);
        return new SuccessResult(Messages.SampleGuideHardDeleted);
    }

    public IDataResult<List<SampleGuide>> GetAll()
    {
        return new SuccessDataResult<List<SampleGuide>>(_sampleGuideDal.GetList().ToList());
    }

    public IDataResult<List<SampleGuide>> GetAllActive()
    {
        return new SuccessDataResult<List<SampleGuide>>(_sampleGuideDal.GetList(sg => sg.IsActive && !sg.IsDeleted).ToList());
    }

    public IDataResult<SampleGuide> GetById(int id)
    {
        return new SuccessDataResult<SampleGuide>(_sampleGuideDal.Get(sg => sg.Id == id));
    }

    public IResult Update(SampleGuide sampleGuide)
    {
        sampleGuide.UpdatedDate = DateTime.Now;
        _sampleGuideDal.Update(sampleGuide);
        return new SuccessResult(Messages.SampleGuideUpdated);
    }
} 