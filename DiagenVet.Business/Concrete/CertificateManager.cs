using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class CertificateManager : ICertificateService
{
    private readonly ICertificateDal _certificateDal;

    public CertificateManager(ICertificateDal certificateDal)
    {
        _certificateDal = certificateDal;
    }

    public IResult Add(Certificate certificate)
    {
        _certificateDal.Add(certificate);
        return new SuccessResult(Messages.CertificateAdded);
    }

    public IResult Delete(Certificate certificate)
    {
        certificate.IsDeleted = true;
        certificate.IsActive = false;
        _certificateDal.Update(certificate);
        return new SuccessResult(Messages.CertificateDeleted);
    }

    public IResult HardDelete(Certificate certificate)
    {
        _certificateDal.Delete(certificate);
        return new SuccessResult(Messages.CertificateHardDeleted);
    }

    public IDataResult<List<Certificate>> GetAll()
    {
        return new SuccessDataResult<List<Certificate>>(_certificateDal.GetList().ToList());
    }

    public IDataResult<List<Certificate>> GetAllActive()
    {
        return new SuccessDataResult<List<Certificate>>(_certificateDal.GetList(c => c.IsActive && !c.IsDeleted).ToList());
    }

    public IDataResult<Certificate> GetById(int id)
    {
        return new SuccessDataResult<Certificate>(_certificateDal.Get(c => c.Id == id));
    }

    public IResult Update(Certificate certificate)
    {
        certificate.UpdatedDate = DateTime.Now;
        _certificateDal.Update(certificate);
        return new SuccessResult(Messages.CertificateUpdated);
    }
} 