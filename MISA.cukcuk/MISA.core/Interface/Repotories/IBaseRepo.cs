using MISA.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.core.Interface.Repotories
{
    public interface IBaseRepo<MisaEntity>
    {
        List<MisaEntity> GetAll();

        int Add(MisaEntity misaEntity);

        int Update(MisaEntity misaEntity, Guid misaEntityId);

        int Delete(Guid misaEntityId);

        MisaEntity GetById(Guid misaEntityID);

        MisaEntity GetCode(string misaEntityCode);
    }
}
