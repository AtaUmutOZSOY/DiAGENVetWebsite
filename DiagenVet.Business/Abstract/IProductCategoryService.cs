using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface IProductCategoryService
{
    IDataResult<ProductCategory> GetById(int id);
    IDataResult<List<ProductCategory>> GetAll();
    IDataResult<List<ProductCategory>> GetAllActive();
    IDataResult<List<ProductCategory>> GetMainCategories();
    IDataResult<List<ProductCategory>> GetSubCategories(int parentId);
    IResult Add(ProductCategory productCategory);
    IResult Update(ProductCategory productCategory);
    IResult Delete(ProductCategory productCategory);
    IResult HardDelete(ProductCategory productCategory);
} 