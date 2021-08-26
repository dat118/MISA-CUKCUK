using MISA.core.Attributes;
using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using MISA.core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.core.Service
{
    public class BaseService<MisaEntity> : IBaseService<MisaEntity>
    {
        IBaseRepo<MisaEntity> _baseRepo;
        ServiceResult _serviceResult;

        public BaseService(IBaseRepo<MisaEntity> baseRepo)
        {
            _baseRepo = baseRepo;
            _serviceResult = new ServiceResult();
        }

        public bool Validation(MisaEntity entity)
        {
            var isValid = true;
            // Thuc hien validate
            var properties = typeof(MisaEntity).GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(entity);
                var propName = prop.Name;

                var MisaRequire = prop.GetCustomAttributes(typeof(MISARequire), true);
                var MisaEmail = prop.GetCustomAttributes(typeof(MISAEmail), true);
                var MisaCode = prop.GetCustomAttributes(typeof(MISACode), true);
                if (MisaRequire.Length > 0)
                {
                    if (prop.PropertyType == typeof(string) && propValue.ToString() == string.Empty)
                    {
                        isValid = false;
                        _serviceResult.Message = "Những thông tin bắt buộc không được phép để trống. ";
                       /*return false;*/
                    }
                }
                if (MisaEmail.Length >0)
                {
                    var formatEmail = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                    var isMatch = Regex.IsMatch(propValue.ToString(), formatEmail, RegexOptions.IgnoreCase);
                    if (isMatch == false)
                    {
                        isValid = false;
                        _serviceResult.Message += "Email không hợp lệ. ";
                        /*return false;*/
                    }
                }
                if (MisaCode.Length > 0)
                {
                    var availableCode = _baseRepo.GetCode(propValue.ToString());
                    if (availableCode != null)
                    {
                        isValid = false;
                        _serviceResult.Message += "Trùng mã. ";
                    }
                }

            }
            return isValid;

        }

        public ServiceResult Add(MisaEntity misaEntity)
        {
            _serviceResult.IsValid = Validation(misaEntity);
            /*if (_serviceResult.IsValid == true)
            {
                _serviceResult.Data = _baseRepo.Add(misaEntity);
            }
            else
            {
                return SatusCode 
            }
*/
            return _serviceResult;
        }

       

        public ServiceResult Update(MisaEntity misaEntity, Guid misaEntityId)
        {
            _serviceResult.IsValid = Validation(misaEntity);
            return _serviceResult;
        }

        
    }
}
