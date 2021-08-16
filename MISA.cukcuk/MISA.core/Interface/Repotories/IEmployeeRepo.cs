using MISA.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Interface.Repotories
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAll();

        int Add(Employee employee);

        int Update(Employee employee, Guid employeeId);

        int Delete(Guid employeeId);
    }
}
