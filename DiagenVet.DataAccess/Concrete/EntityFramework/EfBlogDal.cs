using DiagenVet.Core.DataAccess.EntityFramework;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Contexts;
using DiagenVet.Entity.Concrete;

namespace DiagenVet.DataAccess.Concrete.EntityFramework;

public class EfBlogDal : EfEntityRepositoryBase<Blog, DiagenVetContext>, IBlogDal
{
    public EfBlogDal(DiagenVetContext context) : base(context)
    {
    }
} 