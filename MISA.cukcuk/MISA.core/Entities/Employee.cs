using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Entities
{
    public class Employee:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính      
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>
        /// Giới tính (int)
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email cá nhân
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String PhoneNumber { get; set; }
        /// <summary>
        /// CMND/CCCD
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Lương cơ bản
        /// </summary>
        public string? Salary { get; set; }
        /// <summary>
        /// Tình trạng công việc (int)
        /// </summary>
        public int? WorkStatus { get; set; }
        /// <summary>
        /// ID phòng ban
        /// </summary>
        public string? DepartmentId { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public string? GenderName { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public string? WorkStatusName { get; set; }
        /// <summary>
        /// ID vị trí
        /// </summary>
        public string? PositionId { get; set; }

        #endregion
    }
}
