using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface ISampleGuideService
{
    IDataResult<SampleGuide> GetById(int id);
    IDataResult<List<SampleGuide>> GetAll();
    IDataResult<List<SampleGuide>> GetAllActive();
    IResult Add(SampleGuide sampleGuide);
    IResult Update(SampleGuide sampleGuide);
    IResult Delete(SampleGuide sampleGuide);
    IResult HardDelete(SampleGuide sampleGuide);
} 