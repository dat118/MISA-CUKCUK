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
    public class PositionsController : BaseEntityController<Position>
    {
        IBaseRepo<Position> _baseRepo;
        IBaseService<Position> _baseService;

        public PositionsController(IBaseRepo<Position> baseRepo, IBaseService<Position> baseService) : base(baseRepo, baseService)
        {
            _baseRepo = baseRepo;
            _baseService = baseService;

        }
    }
}
