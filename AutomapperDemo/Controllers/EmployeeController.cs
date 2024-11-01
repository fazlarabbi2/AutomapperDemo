using AutoMapper;
using AutomapperDemo.Model;
using AutomapperDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomapperDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly List<Employee> listEmployees = new()
    {
        new Employee
        {
            Id = 1, Name = "Anurag", Gender = "Male", Email = "Anurag@Example.com",
            Address = new Address { Id = 1001, City = "BBSR", State = "Odisha", Country = "India" }
        },
        new Employee
        {
            Id = 2, Name = "Pranaya", Gender = "Male", Email = "Pranaya@Example.com",
            Address = new Address { Id = 1002, City = "Mumbai", State = "Maharashtra", Country = "India" }
        }
    };

    public EmployeeController(IMapper mapper)
    {
        _mapper = mapper;
    }

    //Return All Employees with Address using EmployeeDTO
    //URL: GET api/Employee
    [HttpGet]
    public ActionResult<List<EmployeeDTO>> GetEmployees()
    {
        // Use AutoMapper to map from Employee to EmployeeDTO
        var employees = _mapper.Map<List<EmployeeDTO>>(listEmployees);

        return Ok(employees);
    }

    //Add a New Employees with Address and return the new Employee using EmployeeDTO
    //URL: POST api/Employee
    //Request Body
    [HttpPost]
    public ActionResult<EmployeeDTO> AddEmployee(EmployeeDTO employeeDTO)
    {
        if (employeeDTO != null && employeeDTO.EmployeeId == 0)
        {
            // Use AutoMapper to map from EmployeeDTO to Employee
            Employee emp = _mapper.Map<Employee>(employeeDTO);

            //Mannually Set the Properties which are not available in DTO
            emp.Id = 3;
            emp.Address.Id = 1003;

            //Adding Employee Object into the Database
            listEmployees.Add(emp);

            //Setting the Employee ID in EmployeeDTO
            employeeDTO.EmployeeId = emp.Id;

            //Returning the EmployeeDTO
            return Ok(employeeDTO);
        }

        //If the Incoming Data in not Valid Return Bad Requestr
        return BadRequest();
    }

    //Update an Existing Employees with Address and return the Updated information
    //URL: PUT api/Employee/1
    //Request Body
    [HttpPut("{EmployeeId}")]
    public ActionResult<Employee> UpdateEmployee(int EmployeeId, EmployeeDTO employeeDTO)
    {
        if (EmployeeId != employeeDTO.EmployeeId) return BadRequest();

        var existingEmployee = listEmployees.FirstOrDefault(emp => emp.Id == EmployeeId);
        if (existingEmployee == null) return NotFound();

        // Reverse mapping: DTO -> Entity
        _mapper.Map(employeeDTO, existingEmployee);

        //Next Update the existingEmployee into the Database

        //For the demonstration we are simply returning the updated employee information
        return Ok(existingEmployee);
    }
}