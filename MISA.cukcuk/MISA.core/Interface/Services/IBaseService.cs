using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Interface.Services
{
    public interface IBaseService<MisaEntity>
    {
   
        ServiceResult Add(MisaEntity misaEntity);

        ServiceResult Update(MisaEntity misaEntity, Guid misaEntityId);
    }
}
