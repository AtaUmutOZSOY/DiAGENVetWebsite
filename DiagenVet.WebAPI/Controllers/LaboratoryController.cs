using DiagenVet.Business.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DiagenVet.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LaboratoryController : ControllerBase
{
    private readonly ILaboratoryService _laboratoryService;

    public LaboratoryController(ILaboratoryService laboratoryService)
    {
        _laboratoryService = laboratoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _laboratoryService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("active")]
    public IActionResult GetAllActive()
    {
        var result = _laboratoryService.GetAllActive();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("with-tests")]
    public IActionResult GetAllWithTests()
    {
        var result = _laboratoryService.GetAllWithTests();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _laboratoryService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult Add(Laboratory laboratory)
    {
        var result = _laboratoryService.Add(laboratory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(Laboratory laboratory)
    {
        var result = _laboratoryService.Update(laboratory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(Laboratory laboratory)
    {
        var result = _laboratoryService.Delete(laboratory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("hard")]
    public IActionResult HardDelete(Laboratory laboratory)
    {
        var result = _laboratoryService.HardDelete(laboratory);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
} 