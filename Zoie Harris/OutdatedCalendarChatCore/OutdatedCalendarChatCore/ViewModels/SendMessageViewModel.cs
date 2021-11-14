using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;


namespace OutdatedCalendarchat.Models
{
    public class SendMessageViewModel
    {
        public MultiSelectList AvailableRecipientList { get; set; }
        public List<int> SelectedRecipientList { get; set; }
        public string Desc { get; set; }
    }
}
