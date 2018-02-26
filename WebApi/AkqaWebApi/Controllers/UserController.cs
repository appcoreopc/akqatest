using Microsoft.AspNetCore.Mvc;
using AkqaWebApi.Models;
using AkqaDataServices.DataModel;
using AkqaWebApi.ServiceLayer;
using AkqaWebApi.Util;

namespace AkqaWebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private AkqaDataStoreContext _context;

        public UserController(AkqaDataStoreContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userService = new UserAmountDataService(_context);
            return HttpResultIntention.GetStatusCode(ActionIntent.Get, true, userService.GetAll());           
        }

        [HttpPost]
        public IActionResult Save([FromBody] UserModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.Username))
            {
                var result = new UserAmountDataService(_context).Save(model);
                return HttpResultIntention.GetStatusCode(ActionIntent.Save, result, null);
            }

            return new BadRequestResult();           
        }
    }
}