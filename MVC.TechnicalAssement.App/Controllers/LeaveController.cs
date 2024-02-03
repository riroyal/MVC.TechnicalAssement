using Logic.TechnicalAssement.App.Enums;
using Logic.TechnicalAssement.App.Models;
using Logic.TechnicalAssement.App.Validator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Logic.TechnicalAssement.App.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILogger<LeaveController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        private const string LeaveRequestsSessionKey = "LeaveRequests";
        
        public List<LeaveViewModel> leaveRequests
        {
            get
            {
                var leaveRequestsString = _httpContextAccessor.HttpContext.Session.GetString(LeaveRequestsSessionKey);
                var leaveRequests = new List<LeaveViewModel>();

                if (leaveRequestsString != null)
                {
                    leaveRequests = JsonConvert.DeserializeObject<List<LeaveViewModel>>(leaveRequestsString);
                }

                return leaveRequests;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.SetString(LeaveRequestsSessionKey, JsonConvert.SerializeObject(value));
            }
        }

        public LeaveController(ILogger<LeaveController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;            
        }

        public IActionResult Index()
        {
            ViewBag.LeaveTypes = Enum.GetValues(typeof(LeaveTypeEnum)).Cast<LeaveTypeEnum>();

            return View(leaveRequests);
        }

        [HttpPost]
        public ActionResult SubmitLeaveRequest(LeaveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingRequest = leaveRequests;
                existingRequest.Add(model);

                leaveRequests = existingRequest;

                return PartialView("_LeaveRequestsPartial", existingRequest);
            }

            return PartialView("_LeaveRequestsPartial", new List<LeaveViewModel>());
        }

        [HttpPost]
        public JsonResult ValidateEmail(string email)
        {
            if (ModelState.IsValid)
            {
                var validator = new EmailAddressValidator();

                if (validator.IsValidFormat(email))
                {
                    return Json(new { valid = true });
                }
                else
                {
                    return Json(new { valid = false, message = "Invalid email address" });
                }
            }

            return Json(new { valid = false, message = "All fields are mandatory" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
