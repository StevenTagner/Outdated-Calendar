using System;
using System.Collections.Generic;

namespace OutdatedCalendarchat.Models
{
    public class SendMessage
    {
        public List<string> AvailableRecipientList { get; set; }
        public List<string> SelectedRecipientList { get; set; }
        public string Desc { get; set; }
    }
}
