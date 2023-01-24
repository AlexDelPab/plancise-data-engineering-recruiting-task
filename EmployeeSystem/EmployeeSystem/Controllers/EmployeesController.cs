using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(ILogger<EmployeesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Produces("application/json")]
    public ImmutableArray<Employee>? Get()
    {
        List<Employee>? employees;

        using (StreamReader r = new("employees.json"))
        {
            string json = r.ReadToEnd();
            employees = JsonSerializer.Deserialize<List<Employee>>(json);
        }

        return employees?.ToImmutableArray();
    }
}