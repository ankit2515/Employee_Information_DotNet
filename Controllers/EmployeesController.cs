using EmployeeContact.Data;
using EmployeeContact.Model;
using EmployeeContact.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;
        public EmployeesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext; 
        }
        [HttpGet]
        public IActionResult GetAllEmp()
        {
            var employee = dBContext.Employee.ToList();
            return Ok(employee);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmpbyId(Guid id) {
            var emp = dBContext.Employee.Find(id);
            if (emp is null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult AddEmp(EmpDto emp) {
            var EmpEntity = new Employee()
            {
                Name = emp.Name,
                Email = emp.Email,
                Phone = emp.Phone,
                Salary = emp.Salary,
            };
            dBContext.Employee.Add(EmpEntity);
            dBContext.SaveChanges();
            return StatusCode(200, "Added Successfully");
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmp(Guid id, updateEmpDto updateDto) {
            var emp = dBContext.Employee.Find(id);
            if (emp is null) {
                return NotFound();
            }
            emp.Name = updateDto.Name;
            emp.Email = updateDto.Email;
            emp.Phone = updateDto.Phone;
            emp.Salary = updateDto.Salary;
            dBContext.Employee.Add(emp);
            dBContext.SaveChanges();
            return StatusCode(201, "Updated Successfully");
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmp(Guid id)
        {
            var emp = dBContext.Employee.Find(id);
            if (emp is null) {
                return NotFound();
            }
            dBContext.Employee.Remove(emp);
            dBContext.SaveChanges();
            return StatusCode(204, "Deleted Successfully");
        }
    }
}
