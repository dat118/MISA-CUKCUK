using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.core.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.cukcuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Get,Post,Put,Delete
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                {
                    // Truy cập vào database
                    // Khai báo thông tin database
                    var connectionString = "Host = 47.241.69.179;" +
                        "Database = MISA.CukCuk_Demo_NVMANH;" +
                        "User Id = dev;" +
                        "Password = 12345678";

                    // khởi tạo đối tượng kết nối với database
                    IDbConnection dbConnetion = new MySqlConnection(connectionString);

                    // Lấy dữ liệu
                    var sqlCommand = "SELECT * from Customer";
                    var customers = dbConnetion.Query<object>(sqlCommand);

                    // Trả về dữ liệu
                    if (customers.Count() > 0)
                    {
                        var response = StatusCode(200, customers);
                        return response;
                    }
                    else
                    {
                        var response = StatusCode(204, customers);
                        return response;
                    }
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

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            try
            {
                // Truy cập vào database
                // Khai báo thông tin database
                var connectionString = "Host = 47.241.69.179;" +
                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                    "User Id = dev;" +
                    "Password = 12345678";

                // khởi tạo đối tượng kết nối với database
                IDbConnection dbConnetion = new MySqlConnection(connectionString);

                // Lấy dữ liệu
                var sqlCommand = $"SELECT * from Customer WHERE CustomerId = @customerParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customerParam", customerId);
                var customer = dbConnetion.Query<object>(sqlCommand, param: parameters);

                // Trả về dữ liệu
                if (customer.Count() > 0)
                {
                    var response = StatusCode(200, customer);
                    return response;
                }
                else
                {
                    var response = StatusCode(204, customer);
                    return response;
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
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            try
            { // Kiểm tra thông tin có hợp lệ không?
                
                // Mã khách hàng bắt buộc phải có
                if (customer.CustomerCode == "" || customer.CustomerCode == null)
                {
                    var errorObj = new
                    {
                        userMsg = Properties.Resources.error_emptyCode,
                        errorCode = Properties.Resources.error_code,
                        moreInfor = Properties.Resources.more_information,
                    };
                    return StatusCode(400, errorObj);
                }

                // Mã khách hàng không được trùng với mã khách hàng đã có

                // Kiểm tra email có đúng định dạng
                var formatEmail = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                var isMatch = Regex.IsMatch(customer.Email,formatEmail, RegexOptions.IgnoreCase);
                if(isMatch == false)
                {
                    var errorObj = new
                    {
                        userMsg = Properties.Resources.error_invalidEmail,
                        errorCode = Properties.Resources.error_code,
                        moreInfor = Properties.Resources.more_information,
                    };
                    return StatusCode(400, errorObj);
                }
                // Truy cập vào database
                // Khai báo thông tin database
                var connectionString = "Host = 47.241.69.179;" +
                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                    "User Id = dev;" +
                    "Password = 12345678";

                // khởi tạo đối tượng kết nối với database
                IDbConnection dbConnetion = new MySqlConnection(connectionString);

                // Khái báo parameters
                DynamicParameters parameters = new DynamicParameters();

                // Thêm dữ liệu vào database
                var colummsName = string.Empty;
                var colummsParam = string.Empty;

                // Đọc property của từng object
                var properties = customer.GetType().GetProperties();

                // Duyệt từng property
                foreach (var prop in properties)
                {
                    // Lấy tên của property
                    var propName = prop.Name;

                    // Lấy value của prop
                    var propValue = prop.GetValue(customer);

                    // Lấy kiểu dữ liệu
                    var propType = prop.PropertyType;

                    // Thêm dữ liệu vào parameter
                    parameters.Add($"@{propName}", propValue);

                    colummsName += $"{propName},";
                    colummsParam += $"@{propName},";
                }
                var sqlCommand = $"INSERT INTO Customer ({colummsName}) VALUES ({colummsParam})";

                var rowEffects = dbConnetion.Execute(sqlCommand, param: parameters);
                // Trả về dữ liệu
                if (rowEffects > 0) {
                    var response = StatusCode(201, rowEffects);
                    return response;
                }
                else
                {
                    var response = StatusCode(204);
                    return response;
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
