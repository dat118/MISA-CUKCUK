using Dapper;
using MISA.core.Entities;
using MISA.core.Interface.Repotories;
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
            throw new NotImplementedException();
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
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id = dev;" +
                "Password = 12345678";

            // khởi tạo đối tượng kết nối với database
            IDbConnection dbConnetion = new MySqlConnection(connectionString);

            // Lấy dữ liệu
            var sqlCommand = "SELECT * from Employee";
            var employees = dbConnetion.Query<Employee>(sqlCommand);

            return employees.ToList();
        }

        public int Update(Employee employee, Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
