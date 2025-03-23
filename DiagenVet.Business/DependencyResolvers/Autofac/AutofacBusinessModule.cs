using Autofac;
using DiagenVet.Business.Abstract;
using DiagenVet.Business.Concrete;
using DiagenVet.DataAccess.Abstract;
using DiagenVet.DataAccess.Concrete.EntityFramework;

namespace DiagenVet.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // About
        builder.RegisterType<AboutManager>().As<IAboutService>();
        builder.RegisterType<EfAboutDal>().As<IAboutDal>();

        // Certificate
        builder.RegisterType<CertificateManager>().As<ICertificateService>();
        builder.RegisterType<EfCertificateDal>().As<ICertificateDal>();

        // Product Category
        builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>();
        builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>();

        // Product
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<EfProductDal>().As<IProductDal>();

        // Laboratory
        builder.RegisterType<LaboratoryManager>().As<ILaboratoryService>();
        builder.RegisterType<EfLaboratoryDal>().As<ILaboratoryDal>();

        // Test
        builder.RegisterType<TestManager>().As<ITestService>();
        builder.RegisterType<EfTestDal>().As<ITestDal>();

        // Sample Guide
        builder.RegisterType<SampleGuideManager>().As<ISampleGuideService>();
        builder.RegisterType<EfSampleGuideDal>().As<ISampleGuideDal>();

        // Blog
        builder.RegisterType<BlogManager>().As<IBlogService>();
        builder.RegisterType<EfBlogDal>().As<IBlogDal>();
    }
} 