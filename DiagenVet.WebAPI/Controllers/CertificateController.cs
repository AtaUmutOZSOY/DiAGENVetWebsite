using DiagenVet.Business.Abstract;
using DiagenVet.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DiagenVet.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _certificateService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("active")]
    public IActionResult GetAllActive()
    {
        var result = _certificateService.GetAllActive();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _certificateService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public IActionResult Add(Certificate certificate)
    {
        var result = _certificateService.Add(certificate);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(Certificate certificate)
    {
        var result = _certificateService.Update(certificate);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    public IActionResult Delete(Certificate certificate)
    {
        var result = _certificateService.Delete(certificate);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete("hard")]
    public IActionResult HardDelete(Certificate certificate)
    {
        var result = _certificateService.HardDelete(certificate);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
} 