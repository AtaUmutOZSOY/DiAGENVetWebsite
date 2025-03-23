using DiagenVet.Business.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DiagenVet.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _blogService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("active")]
    public IActionResult GetAllActive()
    {
        var result = _blogService.GetAllActive();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("published")]
    public IActionResult GetAllPublished()
    {
        var result = _blogService.GetAllPublished();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("tag/{tag}")]
    public IActionResult GetAllByTag(string tag)
    {
        var result = _blogService.GetAllByTag(tag);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _blogService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("slug/{slug}")]
    public IActionResult GetBySlug(string slug)
    {
        var result = _blogService.GetBySlug(slug);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult Add(Blog blog)
    {
        var result = _blogService.Add(blog);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(Blog blog)
    {
        var result = _blogService.Update(blog);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(Blog blog)
    {
        var result = _blogService.Delete(blog);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("hard")]
    public IActionResult HardDelete(Blog blog)
    {
        var result = _blogService.HardDelete(blog);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("increment-view/{id}")]
    public IActionResult IncrementViewCount(int id)
    {
        var result = _blogService.IncrementViewCount(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
} 