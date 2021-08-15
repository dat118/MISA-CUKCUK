using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Entities
{
    public class Customer:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính      
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và đệm
        /// </summary>
        public String? FirstName { get; set; }
        /// <summary>
        /// Tên
        /// </summary>
        public String? LastName { get; set; }
        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        public String? FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public String? Address { get; set; }
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
        /// Số nợ
        /// </summary>
        public double? DebitAmount { get; set; }
        /// <summary>
        /// Thẻ thành viên
        /// </summary>
        public String? MemberCardCode { get; set; }
        /// <summary>
        /// Tên Công ty
        /// </summary>
        public String? CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string? CompanyTaxCode { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? IsStopFollow { get; set; }

        #endregion

    }
}
