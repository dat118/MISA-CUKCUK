﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Entities
{
    class Department:BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khóa chính      
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Miêu tả phòng ban
        /// </summary>
        public string? Description { get; set; }

        #endregion
    }
}
