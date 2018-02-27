using Microsoft.AspNetCore.Mvc;
using AkqaWebApi.Models;
using AkqaDataServices.DataModel;
using AkqaWebApi.ServiceLayer;
using AkqaWebApi.Util;
using Microsoft.Extensions.Logging;

namespace AkqaWebApi.Controllers
{


    public class UserController : Controller
    {
        private readonly AkqaDataStoreContext _context;
        private readonly ILogger _logger;

        public UserController(AkqaDataStoreContext _context, ILogger<UserController> logger)
        {
            this._context = _context;
            this._logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var userService = new UserAmountDataService(_context);
            return HttpResultIntention.GetStatusCode(ActionIntent.Get, true, userService.GetAll());           
        }

        [HttpPost(Name ="Save")]
        public IActionResult Save([FromBody] UserModel model)
        {
            _logger.LogInformation(AppConstants.UserSaveControllerMethodRequest);
           if (model != null && !string.IsNullOrEmpty(model.Username))
            {
                var result = new UserAmountDataService(_context).Save(model);
                _logger.LogInformation($"{AppConstants.UserSaveControllerMethodStatus} {result}");
                return HttpResultIntention.GetStatusCode(ActionIntent.Save, result, null);
            }

            return new BadRequestResult();           
        }
    }
}