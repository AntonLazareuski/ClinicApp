using ClinicApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClinicController : ControllerBase
{
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    [HttpGet("{id}")]
    public IActionResult GetClinic(int id, string[] columns)
    {
        var clinicData = _clinicService.GetClinic(id, columns);
        if (clinicData == null)
        {
            return NotFound();
        }

        return Ok(clinicData);
    }

    [HttpGet]
    public IActionResult GetClinics(int page, string[] columns)
    {
        var clinicListData = _clinicService.GetClinics(page, columns);
        if (clinicListData == null)
        {
            return NotFound();
        }

        return Ok(clinicListData);
    }
}
