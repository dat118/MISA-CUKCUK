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
    public class CustomerGroupsController : BaseEntityController<CustomerGroup>
    {
        IBaseRepo<CustomerGroup> _baseRepo;
        IBaseService<CustomerGroup> _baseService;

        public CustomerGroupsController(IBaseRepo<CustomerGroup> baseRepo, IBaseService<CustomerGroup> baseService) : base(baseRepo, baseService)
        {
            _baseRepo = baseRepo;
            _baseService = baseService;

        }
    }
}
