using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class ProductCategoryManager : IProductCategoryService
{
    private readonly IProductCategoryDal _productCategoryDal;

    public ProductCategoryManager(IProductCategoryDal productCategoryDal)
    {
        _productCategoryDal = productCategoryDal;
    }

    public IResult Add(ProductCategory productCategory)
    {
        _productCategoryDal.Add(productCategory);
        return new SuccessResult(Messages.ProductCategoryAdded);
    }

    public IResult Delete(ProductCategory productCategory)
    {
        productCategory.IsDeleted = true;
        productCategory.IsActive = false;
        _productCategoryDal.Update(productCategory);
        return new SuccessResult(Messages.ProductCategoryDeleted);
    }

    public IResult HardDelete(ProductCategory productCategory)
    {
        _productCategoryDal.Delete(productCategory);
        return new SuccessResult(Messages.ProductCategoryHardDeleted);
    }

    public IDataResult<List<ProductCategory>> GetAll()
    {
        return new SuccessDataResult<List<ProductCategory>>(_productCategoryDal.GetList().ToList());
    }

    public IDataResult<List<ProductCategory>> GetAllActive()
    {
        return new SuccessDataResult<List<ProductCategory>>(_productCategoryDal.GetList(pc => pc.IsActive && !pc.IsDeleted).ToList());
    }

    public IDataResult<ProductCategory> GetById(int id)
    {
        return new SuccessDataResult<ProductCategory>(_productCategoryDal.Get(pc => pc.Id == id));
    }

    public IDataResult<List<ProductCategory>> GetMainCategories()
    {
        return new SuccessDataResult<List<ProductCategory>>(
            _productCategoryDal.GetList(pc => pc.ParentCategoryId == null && pc.IsActive && !pc.IsDeleted).ToList());
    }

    public IDataResult<List<ProductCategory>> GetSubCategories(int parentId)
    {
        return new SuccessDataResult<List<ProductCategory>>(
            _productCategoryDal.GetList(pc => pc.ParentCategoryId == parentId && pc.IsActive && !pc.IsDeleted).ToList());
    }

    public IResult Update(ProductCategory productCategory)
    {
        productCategory.UpdatedDate = DateTime.Now;
        _productCategoryDal.Update(productCategory);
        return new SuccessResult(Messages.ProductCategoryUpdated);
    }
} 