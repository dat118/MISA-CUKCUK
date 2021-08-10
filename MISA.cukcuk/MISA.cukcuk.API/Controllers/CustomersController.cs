using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.cukcuk.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.cukcuk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Get,Post,Put,Delete

        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return null;
        }
    }
}
