using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface ICertificateService
{
    IDataResult<Certificate> GetById(int id);
    IDataResult<List<Certificate>> GetAll();
    IDataResult<List<Certificate>> GetAllActive();
    IResult Add(Certificate certificate);
    IResult Update(Certificate certificate);
    IResult Delete(Certificate certificate);
    IResult HardDelete(Certificate certificate);
} 