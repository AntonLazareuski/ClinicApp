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



    [HttpGet]
    public IActionResult GetClinic([FromQuery]int id, [FromQuery]string[] columns)
    {

        var clinicData = _clinicService.GetClinic(id, columns);
        if (clinicData == null)
        {
            return NotFound();
        }

        return Ok(clinicData);
    }

    /*[HttpGet]*/
    /*public IActionResult GetClinics(int page, string[] columns)
    {
        var clinicListData = _clinicService.GetClinics(page, columns);
        if (clinicListData == null)
        {
            return NotFound();
        }

        return Ok(clinicListData);
    }*/
}
