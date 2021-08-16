using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using MISA.core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MISA.core.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepo _employeeRepo;
        ServiceResult _serviceResult;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _serviceResult = new ServiceResult();
            _employeeRepo = employeeRepo;
        }

        public ServiceResult Add(Employee employee)
        {   //Validate

            //Them moi
            _serviceResult.Data = _employeeRepo.Add(employee);
            return _serviceResult;
        }

        public ServiceResult Update(Employee employee, Guid employeeId)
        {
            //Validate

            //Sua doi
            _serviceResult.Data = _employeeRepo.Update(employee,employeeId);
            return _serviceResult;
        }
    }
}
