using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.core.Entities;
using MISA.core.Interface.Repotories;
using MISA.core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.cukcuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseEntityController<Department>

    {
        IBaseRepo<Department> _baseRepo;
        IBaseService<Department> _baseService;

        public DepartmentsController(IBaseRepo<Department> baseRepo, IBaseService<Department> baseService) : base(baseRepo, baseService)
        {
            _baseRepo = baseRepo;
            _baseService = baseService;

        }
    }
}
