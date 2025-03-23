using DiagenVet.Business.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DiagenVet.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _testService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("active")]
    public IActionResult GetAllActive()
    {
        var result = _testService.GetAllActive();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("laboratory/{laboratoryId}")]
    public IActionResult GetAllByLaboratory(int laboratoryId)
    {
        var result = _testService.GetAllByLaboratory(laboratoryId);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _testService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult Add(Test test)
    {
        var result = _testService.Add(test);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(Test test)
    {
        var result = _testService.Update(test);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(Test test)
    {
        var result = _testService.Delete(test);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("hard")]
    public IActionResult HardDelete(Test test)
    {
        var result = _testService.HardDelete(test);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
} 