using Dapper;
using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace MISA.infrastructure.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public int Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.MF935.NDDAT;" +
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
            var properties = employee.GetType().GetProperties();

            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của property
                var propName = prop.Name;

                // Lấy value của prop
                var propValue = prop.GetValue(employee);

                // Lấy kiểu dữ liệu
                var propType = prop.PropertyType;

                // Thêm dữ liệu vào parameter
                parameters.Add($"@{propName}", propValue);

                colummsName += $"{propName},";
                colummsParam += $"@{propName},";
            }
            var sqlCommand = $"INSERT INTO Employee ({colummsName}) VALUES ({colummsParam})";

            var rowEffects = dbConnetion.Execute(sqlCommand, param: parameters);
            // Trả về dữ liệu
            return rowEffects;
        }

        public int Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            // Truy cập vào database
            // Khai báo thông tin database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.MF935.NDDAT;" +
                "User Id = dev;" +
                "Password = 12345678";

            // khởi tạo đối tượng kết nối với database
            IDbConnection dbConnetion = new MySqlConnection(connectionString);

            // Lấy dữ liệu
            var sqlCommand = "SELECT * from Employee";
            var employees = dbConnetion.Query<Employee>(sqlCommand);

            return employees.ToList();
        }

        public Employee GetById(Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public Employee GetCode(string misaEntityCode)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee, Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
