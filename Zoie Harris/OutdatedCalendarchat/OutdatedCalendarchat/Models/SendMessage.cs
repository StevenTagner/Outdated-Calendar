using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OutdatedCalendarchat.Models
{
    public class SendMessage
    {
        public MultiSelectList AvailableRecipientList { get; set; }
        public List<int> SelectedRecipientList { get; set; }
        public string Desc { get; set; }
    }
}
