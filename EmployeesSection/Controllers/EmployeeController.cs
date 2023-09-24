using EmployeesSection.DAL;
using EmployeesSection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesSection.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext db;
        public EmployeeController(EmployeeContext db)
        {
            this.db = db;
        }

        // GET: api/employee
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employee.ToList();
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
                throw new Exception("Такой сотрудник не найден");
            else 
                return employee;
        }

        // POST api/employee
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            if (employee.FullName == null || employee.JobTitle == null)
                throw new Exception("Недостаточно данных");

            var hasEmployee = db.Employee.Where(p=>p.FullName == employee.FullName).FirstOrDefault();
            if (hasEmployee != default)
                throw new Exception("Такой сотрудник уже создан");
            else
            {
                try
                {
                    db.Employee.Add(employee);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            if (employee.FullName == null || employee.JobTitle == null)
                throw new Exception("Недостаточно данных");

            var hasEmployee = db.Employee.Where(p => p.FullName == employee.FullName).FirstOrDefault();
            if (hasEmployee != default && hasEmployee.ID != id)
                throw new Exception("Такой сотрудник уже создан");
            else
            {
                try
                {
                    var updatedEmployee = db.Employee.Find(id);
                    updatedEmployee.UpdateEmployee(employee.FullName, employee.JobTitle);
                    db.Employee.Add(updatedEmployee);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
                throw new Exception("Такой сотрудник не найден");
            else
            {
                try
                {
                    db.Employee.Remove(employee);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
