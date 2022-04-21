using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierModel>> Get()
        {
            var supplierList = supplierService.GetAllSuppliers();
            return Ok(supplierList);
        }
    }
}
