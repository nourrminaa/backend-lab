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
    public async Task<IActionResult> Get()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Thread " + Environment.CurrentManagedThreadId + " (GET /api/data): " + i);
            await Task.Delay(500);
        }

        var data = await _service.GetAll();
        if (data == null || data.Count == 0)
            return NotFound(); // 404
        return Ok(data); // 200 + JSON
    }

    // Task to crate a random calculation using continuation to pick up the result once the task completes
    [HttpGet("random")]
    public async Task<IActionResult> GetRandom()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Thread " + Environment.CurrentManagedThreadId + " (GET /api/data/random): " + i);
            await Task.Delay(500);
        }
        
        Task<int> calculationTask = Task.Run(CalculateRandomSum);

        Task<int> continuationTask = calculationTask.ContinueWith(GetTaskResult);

        int result = await continuationTask;

        return Ok(new { RandomCalculationResult = result });
    }

    // Runs the random calculation itself (the work the Task performs)
    private static int CalculateRandomSum()
    {
        var random = new Random();
        int number = random.Next(1, 500);
        int sum = 0;

        for (int i = 1; i <= number; i++)
            sum += i * i;

        return sum;
    }

    // The continuation: runs once calculationTask completes and picks up its result
    private static int GetTaskResult(Task<int> completedTask)
    {
        return completedTask.Result;
    }
}