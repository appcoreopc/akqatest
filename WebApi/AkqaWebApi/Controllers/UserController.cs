//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace AkqaWebApi.Controllers
//{
//    public class UserController : Controller
//    {
//        private PTSContext _ptsContext;

//        public UserController(PTSContext ptsContext)
//        {
//            _ptsContext = ptsContext;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }
        
//        [HttpPost]
//        public IActionResult Save([FromBody] UserModel model)
//        {
//            return View();
//        }
//    }
//}