﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using MISA.core.Interface.Services;
using MISA.core.Service;
using MISA.infrastructure.Repo;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.cukcuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>

    {
        IBaseRepo<Employee> _baseRepo;
        IBaseService<Employee> _baseService;
        IEmployeeRepo _employeeRepo;
        public EmployeesController(IEmployeeRepo employeeRepo, IBaseRepo<Employee> baseRepo, IBaseService<Employee> baseService) : base(baseRepo, baseService)
        {
            _baseRepo = baseRepo;
            _baseService = baseService;
            _employeeRepo = employeeRepo;
        }
        [HttpPost("Import")]

        public IActionResult Import (IFormFile formFile)
        {
            try
            { var employees = new List<Employee>();
                // Check file có hợp lệ không
                if(formFile == null) {
                    var errorObj = new
                    {
                        devMsg = "Null File",
                        userMsg = "Vui lòng chọn tệp nhập khẩu",
                        errorCode = Properties.Resources.error_code,
                        moreInfor = Properties.Resources.more_information,
                    };
                    return StatusCode(400, errorObj);
                }
                
                // Check độ lớn của file

                // Thực hiện đọc file
                using (var stream = new MemoryStream())
                {
                    formFile.CopyToAsync(stream, System.Threading.CancellationToken.None);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 3; row <= rowCount; row++)
                        {
                            var error = "";
                            // Mã nhân viên
                            var employeeCode = worksheet.Cells[row, 1].Value;
                            
                            // Họ và tên
                            var fullName = worksheet.Cells[row, 2].Value;

                            // Email
                            var formatEmail = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
  
                            var email = worksheet.Cells[row, 9].Value;

                            if (email == null) email = "";

                            var isMatch = Regex.IsMatch(email.ToString(), formatEmail, RegexOptions.IgnoreCase);

                            // Số điện thoại
                            var phoneNumber = worksheet.Cells[row, 5].Value;

                            /*// Ngày sinh
                            var date = worksheet.Cells[row, 6].Value.ToString().Trim();
                            DateTime dateOfBirth = Convert.ToDateTime(date);
*/
                            if (employeeCode == null)
                            {
                                employeeCode = "";
                                error = "Mã nhân viên không được phép để trống. ";
                            };
                            if (_baseRepo.GetCode(employeeCode.ToString()) != null)
                            {
                                error += "Mã nhân viên đã bị trùng. ";
                            }
                            if (fullName == null)
                            {
                                fullName = "";
                                error += "Tên nhân viên không được phép để trống. ";
                            };
                            if(isMatch == false )
                            {
                                error += "Email không hợp lệ. ";
                            };
                            if (phoneNumber == null)
                            {
                                phoneNumber = "";                              
                                error += "Số điện thoại không được phép để trống. ";
                            }
                            
                            var employee = new Employee
                            {
                                EmployeeId = Guid.NewGuid(),
                                EmployeeCode = employeeCode.ToString().Trim(),
                                FullName = fullName.ToString().Trim(),
                                PhoneNumber = phoneNumber.ToString().Replace(".", "").Trim(),
                                /*DateOfBirth = dateOfBirth,*/
                                PersonalTaxCode = worksheet.Cells[row, 8].Value.ToString().Trim(),
                                Email = email.ToString().Trim(),
                                Address = worksheet.Cells[row, 10].Value.ToString().Trim(),
                                Error = error
                            };
                            

                            employees.Add(employee);
                        }
                    }
                }
                return StatusCode(200,employees);
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

        

        /*[HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _employeeRepo.GetAll();
                 
                return StatusCode(200,employees);
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
                    var rowEffect = _employeeRepo.Add(employee);
                    return StatusCode(201,rowEffect);
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
    }*/
    }
}
