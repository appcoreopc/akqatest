using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AkqaWebApi.Models;
using AkqaDataServices.DataModel;

namespace AkqaWebApi.Controllers
{
    public class UserController : Controller
    {
        private AkqaDataStoreContext _ptsContext;

        public UserController(AkqaDataStoreContext _context)
        {
            _ptsContext = _context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save([FromBody] UserModel model)
        {
            return View();
        }
    }
}