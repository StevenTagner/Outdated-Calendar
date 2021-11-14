using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using OutdatedCalendarchat.Models;

namespace OutdatedCalendarchat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AllMessages()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            List<Message> messages = new List<Message>();
            var testMessage = new Message
            {
                From = "Chuck",
                To = "Zoie",
                Desc = "This is a test",
                SentDate = DateTime.Now
            };
            messages.Add(testMessage);
            ViewBag.Messages = messages;
            return View();
        }
        public ActionResult SendMessage()
        {
            var sendMessage = new SendMessage();
            List<Recipient> recipients = new List<Recipient>();
            recipients.Add(new Recipient { Name = "Chuck" });
            recipients.Add(new Recipient { Name = "Tom" });
            recipients.Add(new Recipient { Name = "John" });
            sendMessage.AvailableRecipientList = new MultiSelectList(recipients,"Id","Name");
            return View(sendMessage);
        }
    }
}
