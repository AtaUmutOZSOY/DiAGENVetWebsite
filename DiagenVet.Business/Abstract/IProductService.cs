using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface IProductService
{
    IDataResult<Product> GetById(int id);
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllActive();
    IDataResult<List<Product>> GetAllByCategory(int categoryId);
    IResult Add(Product product);
    IResult Update(Product product);
    IResult Delete(Product product);
    IResult HardDelete(Product product);
} 