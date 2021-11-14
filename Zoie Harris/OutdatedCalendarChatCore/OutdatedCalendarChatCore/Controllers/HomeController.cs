using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OutdatedCalendarchat.Models;
using OutdatedCalendarChatCore.Models;
using OutdatedCalendarChatCore.Services;

namespace OutdatedCalendarChatCore.Controllers
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
            List<RecipientViewModel> recipients = new List<RecipientViewModel>();
            recipients.Add(new RecipientViewModel { Name = "Chuck" });
            recipients.Add(new RecipientViewModel { Name = "Tom" });
            recipients.Add(new RecipientViewModel { Name = "John" });
            sendMessage.AvailableRecipientList = new MultiSelectList(recipients, "Id", "Name");
            return View(sendMessage);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
