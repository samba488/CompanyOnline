using CompanyOnline.API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOnline.API.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee, long>
    {
        ApplicationContext ctx;
        public EmployeeManager(ApplicationContext c)
        {
            ctx = c;
        }

        public Employee Get(long id)
        {
            var employee = ctx.Employees.FirstOrDefault(b => b.Id == id);
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            var companies = ctx.Employees.ToList();
            return companies;
        }

        public long Add(Employee employee)
        {
            ctx.Employees.Add(employee);
            long employeeId = ctx.SaveChanges();
            return employeeId;
        }

        public long Update(long id, Employee item)
        {
            long employeeId = 0;
            var employee = ctx.Employees.Find(id);
            if (employee != null)
            {
                employee.First_Name = item.First_Name;
                employee.Last_Name = item.Last_Name;
                employee.Address = item.Address;
                employee.Phone_Number = item.Phone_Number;
                employee.Salary = item.Salary;
                employee.Email = item.Email;
                employee.Company_Id = item.Company_Id;
                employeeId = ctx.SaveChanges();
            }
            return employeeId;
        }

        public long Delete(long id)
        {
            int employeeId = 0;
            var employee = ctx.Employees.FirstOrDefault(b => b.Id == id);
            if (employee != null)
            {
                ctx.Employees.Remove(employee);
                employeeId = ctx.SaveChanges();
            }
            return employeeId;
        }
    }
}
