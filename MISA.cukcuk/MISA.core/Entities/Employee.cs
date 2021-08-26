using MISA.core.Attributes;
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
        [MISARequire,MISACode]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        [MISARequire]
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
        [MISAEmail]
        public String Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [MISARequire]
        public String PhoneNumber { get; set; }
        /// <summary>
        /// CMND/CCCD
        /// </summary>
        [MISARequire]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }
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
        public Guid? DepartmentId { get; set; }
        
        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string? PersonalTaxCode { get; set; }
        /// <summary>
        /// Tình trạng quan hệ
        /// </summary>
        public int? MartialStatus { get; set; }
        /// <summary>
        /// Trình độ học vấn    
        /// </summary>
        public string? EducationalBackground { get; set; }
        /// <summary>
        /// Bằng cấp
        /// </summary>
        public string? QualificationId { get; set; }
        /// <summary>
        /// Ngày gia nhập  
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Lỗi khi nhập khẩu
        /// </summary>
        [MISANotMap]
        public string? Error { get; set; }
        #endregion
    }
}
