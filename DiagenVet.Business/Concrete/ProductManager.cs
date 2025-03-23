using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IResult Add(Product product)
    {
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IResult Delete(Product product)
    {
        product.IsDeleted = true;
        product.IsActive = false;
        _productDal.Update(product);
        return new SuccessResult(Messages.ProductDeleted);
    }

    public IResult HardDelete(Product product)
    {
        _productDal.Delete(product);
        return new SuccessResult(Messages.ProductHardDeleted);
    }

    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
    }

    public IDataResult<List<Product>> GetAllActive()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.IsActive && !p.IsDeleted).ToList());
    }

    public IDataResult<List<Product>> GetAllByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(
            _productDal.GetList(p => p.CategoryId == categoryId && p.IsActive && !p.IsDeleted).ToList());
    }

    public IDataResult<Product> GetById(int id)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
    }

    public IResult Update(Product product)
    {
        product.UpdatedDate = DateTime.Now;
        _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
    }
} 