using DiagenVet.Business.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DiagenVet.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _productCategoryService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("active")]
    public IActionResult GetAllActive()
    {
        var result = _productCategoryService.GetAllActive();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("main")]
    public IActionResult GetMainCategories()
    {
        var result = _productCategoryService.GetMainCategories();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("sub/{parentId}")]
    public IActionResult GetSubCategories(int parentId)
    {
        var result = _productCategoryService.GetSubCategories(parentId);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _productCategoryService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult Add(ProductCategory productCategory)
    {
        var result = _productCategoryService.Add(productCategory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(ProductCategory productCategory)
    {
        var result = _productCategoryService.Update(productCategory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(ProductCategory productCategory)
    {
        var result = _productCategoryService.Delete(productCategory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("hard")]
    public IActionResult HardDelete(ProductCategory productCategory)
    {
        var result = _productCategoryService.HardDelete(productCategory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
} 