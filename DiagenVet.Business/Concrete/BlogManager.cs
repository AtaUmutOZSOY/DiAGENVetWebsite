using DiagenVet.Business.Abstract;
using DiagenVet.Business.Constants;
using DiagenVet.Core.Results;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.Business.Concrete;

public class BlogManager : IBlogService
{
    private readonly IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public IResult Add(Blog blog)
    {
        blog.PublishDate = DateTime.Now;
        _blogDal.Add(blog);
        return new SuccessResult(Messages.BlogAdded);
    }

    public IResult Delete(Blog blog)
    {
        blog.IsDeleted = true;
        blog.IsActive = false;
        _blogDal.Update(blog);
        return new SuccessResult(Messages.BlogDeleted);
    }

    public IResult HardDelete(Blog blog)
    {
        _blogDal.Delete(blog);
        return new SuccessResult(Messages.BlogHardDeleted);
    }

    public IDataResult<List<Blog>> GetAll()
    {
        return new SuccessDataResult<List<Blog>>(_blogDal.GetList().ToList());
    }

    public IDataResult<List<Blog>> GetAllActive()
    {
        return new SuccessDataResult<List<Blog>>(_blogDal.GetList(b => b.IsActive && !b.IsDeleted).ToList());
    }

    public IDataResult<List<Blog>> GetAllByTag(string tag)
    {
        return new SuccessDataResult<List<Blog>>(
            _blogDal.GetList(b => b.Tags != null && b.Tags.Contains(tag) && b.IsActive && !b.IsDeleted && b.IsPublished).ToList());
    }

    public IDataResult<List<Blog>> GetAllPublished()
    {
        return new SuccessDataResult<List<Blog>>(
            _blogDal.GetList(b => b.IsActive && !b.IsDeleted && b.IsPublished).ToList());
    }

    public IDataResult<Blog> GetById(int id)
    {
        return new SuccessDataResult<Blog>(_blogDal.Get(b => b.Id == id));
    }

    public IDataResult<Blog> GetBySlug(string slug)
    {
        return new SuccessDataResult<Blog>(_blogDal.Get(b => b.Slug == slug && b.IsActive && !b.IsDeleted));
    }

    public IResult IncrementViewCount(int id)
    {
        var blog = _blogDal.Get(b => b.Id == id);
        if (blog == null)
            return new ErrorResult("Blog bulunamadı.");

        blog.ViewCount++;
        _blogDal.Update(blog);
        return new SuccessResult();
    }

    public IResult Update(Blog blog)
    {
        blog.UpdatedDate = DateTime.Now;
        _blogDal.Update(blog);
        return new SuccessResult(Messages.BlogUpdated);
    }
} 