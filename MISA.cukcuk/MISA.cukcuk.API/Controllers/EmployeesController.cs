using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using MISA.core.Interface.Services;
using MISA.core.Service;
using MISA.infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.cukcuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase

    {
        IEmployeeRepo _employeeRepo;
        IEmployeeService _employeeService;

        public EmployeesController (IEmployeeRepo employeeRepo, IEmployeeService employeeService)
        {
             _employeeRepo = employeeRepo;
             _employeeService = employeeService;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _employeeRepo.GetAll();
                 
                return Ok(employees);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                var res = _employeeService.Add(employee);
                if (res.IsValid == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.error_userMsg,
                    errorCode = Properties.Resources.error_code,
                    moreInfor = Properties.Resources.more_information,
                };
                return StatusCode(500, errorObj);
            }
            
        }
    }
}
