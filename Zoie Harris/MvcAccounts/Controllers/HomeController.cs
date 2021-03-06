using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcAccounts.Models;
using OutdatedCalendarchat.Models;
using OutdatedCalendarChatCore.Services;
using System.Diagnostics;

namespace MvcAccounts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MessagingService messagingService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            messagingService = new MessagingService();

        }
        public ActionResult AllMessages()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            List<MessageViewModel> messages = messagingService.GetMessagesByPersonId(1);
            ViewBag.Messages = messages;
            return View();
        }
        public ActionResult SendMessage()
        {
            var sendMessage = new SendMessageViewModel();
            List<RecipientViewModel> recipients = messagingService.GetRecipients();
            sendMessage.AvailableRecipientList = new MultiSelectList(recipients, "Id", "Name");
            return View(sendMessage);
        }
        [HttpPost]
        public ActionResult SendMessage(SendMessageViewModel sendMessageViewModel)
        {
            //messagingService.SendMessage(sendMessageViewModel);
            return RedirectToAction("AllMessages");
        }
        public IActionResult Index()
        {
            return View();
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