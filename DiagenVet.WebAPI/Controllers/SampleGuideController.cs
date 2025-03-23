using DiagenVet.Business.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DiagenVet.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SampleGuideController : ControllerBase
{
    private readonly ISampleGuideService _sampleGuideService;

    public SampleGuideController(ISampleGuideService sampleGuideService)
    {
        _sampleGuideService = sampleGuideService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _sampleGuideService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("active")]
    public IActionResult GetAllActive()
    {
        var result = _sampleGuideService.GetAllActive();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _sampleGuideService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult Add(SampleGuide sampleGuide)
    {
        var result = _sampleGuideService.Add(sampleGuide);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(SampleGuide sampleGuide)
    {
        var result = _sampleGuideService.Update(sampleGuide);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(SampleGuide sampleGuide)
    {
        var result = _sampleGuideService.Delete(sampleGuide);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("hard")]
    public IActionResult HardDelete(SampleGuide sampleGuide)
    {
        var result = _sampleGuideService.HardDelete(sampleGuide);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
} 