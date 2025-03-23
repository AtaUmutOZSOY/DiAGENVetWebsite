using DiagenVet.Core.Results;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Abstract;

public interface IBlogService
{
    IDataResult<Blog> GetById(int id);
    IDataResult<Blog> GetBySlug(string slug);
    IDataResult<List<Blog>> GetAll();
    IDataResult<List<Blog>> GetAllActive();
    IDataResult<List<Blog>> GetAllPublished();
    IDataResult<List<Blog>> GetAllByTag(string tag);
    IResult Add(Blog blog);
    IResult Update(Blog blog);
    IResult Delete(Blog blog);
    IResult HardDelete(Blog blog);
    IResult IncrementViewCount(int id);
} 