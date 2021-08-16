using MISA.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Interface.Services
{
    public interface IEmployeeService
    {
        ServiceResult Add(Employee employee);

        ServiceResult Update(Employee employee, Guid employeeId);
    }
}
