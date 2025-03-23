using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiagenVet.Business.Concrete;

public class LaboratoryManager : ILaboratoryService
{
    private readonly ILaboratoryDal _laboratoryDal;

    public LaboratoryManager(ILaboratoryDal laboratoryDal)
    {
        _laboratoryDal = laboratoryDal;
    }

    public IResult Add(Laboratory laboratory)
    {
        _laboratoryDal.Add(laboratory);
        return new SuccessResult(Messages.LaboratoryAdded);
    }

    public IResult Delete(Laboratory laboratory)
    {
        laboratory.IsDeleted = true;
        laboratory.IsActive = false;
        _laboratoryDal.Update(laboratory);
        return new SuccessResult(Messages.LaboratoryDeleted);
    }

    public IResult HardDelete(Laboratory laboratory)
    {
        _laboratoryDal.Delete(laboratory);
        return new SuccessResult(Messages.LaboratoryHardDeleted);
    }

    public IDataResult<List<Laboratory>> GetAll()
    {
        return new SuccessDataResult<List<Laboratory>>(_laboratoryDal.GetList().ToList());
    }

    public IDataResult<List<Laboratory>> GetAllActive()
    {
        return new SuccessDataResult<List<Laboratory>>(_laboratoryDal.GetList(l => l.IsActive && !l.IsDeleted).ToList());
    }

    public IDataResult<List<Laboratory>> GetAllWithTests()
    {
        var context = _laboratoryDal.Context;
        var result = context.Set<Laboratory>()
            .Include(l => l.Tests.Where(t => t.IsActive && !t.IsDeleted))
            .Where(l => l.IsActive && !l.IsDeleted)
            .ToList();
        return new SuccessDataResult<List<Laboratory>>(result);
    }

    public IDataResult<Laboratory> GetById(int id)
    {
        var laboratory = _laboratoryDal.Get(l => l.Id == id);
        return laboratory == null
            ? new ErrorDataResult<Laboratory>("Laboratuvar bulunamadı.")
            : new SuccessDataResult<Laboratory>(laboratory);
    }

    public IResult Update(Laboratory laboratory)
    {
        laboratory.UpdatedDate = DateTime.Now;
        _laboratoryDal.Update(laboratory);
        return new SuccessResult(Messages.LaboratoryUpdated);
    }
} 