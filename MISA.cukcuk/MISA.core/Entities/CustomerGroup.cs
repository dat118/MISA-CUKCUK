using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Entities
{
    public class CustomerGroup:BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm
        /// </summary>
        public String CustomerGroupName { get; set; }
        /// <summary>
        /// Miêu tả
        /// </summary>
        public String Description { get; set; }
        #endregion
    }
}
