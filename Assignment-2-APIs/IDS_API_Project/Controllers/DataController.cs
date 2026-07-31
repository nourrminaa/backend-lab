/* 
    The controller folder acts as the application's "traffic cop" 

    It intercepts incoming HTTP requests and routes them to the appropriate 
    backend functions

    Positioned as an intermediary layer, controllers orchestrate data flow between 
    views (presentation layer) and the core logic, APIs or database models.

    Note: also, this is the layer the client interacts with.
*/

using IDS_API_Project.Services;
using Microsoft.AspNetCore.Mvc; // To use ControllerBase and IActionResult

namespace IDS_API_Project.Controllers;

[ApiController]
[Route("api/data")] // So now the GET testing will be on localhost:5015/api/data
public class DataController : ControllerBase
{
    private readonly IDataService _service;

    public DataController(IDataService service)
    {
        _service = service;
    } 

    [HttpGet]
    public IActionResult Get()
    {
        var data = _service.GetAll();
        if (data == null || data.Count == 0)
            return NotFound(); // 404
        return Ok(data); // 200 + JSON
    }
}
