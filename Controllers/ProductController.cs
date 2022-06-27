
using EcommerceApi.Interfaces;
using EcommerceApi.Models;
using EcommerceApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        EcommerceDBContext db;
        public ProductController(EcommerceDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<TblProduct> GetProducts()
        {
            return db.TblProducts;
        }
    }
}