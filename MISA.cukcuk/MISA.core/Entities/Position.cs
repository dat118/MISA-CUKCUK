using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Entities
{
   public class Position:BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Miêu tả vị trí
        /// </summary>
        public string? Description { get; set; }
        #endregion
    }
}
