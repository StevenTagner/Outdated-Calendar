using System;
namespace OutdatedCalendarchat.Models
{
    public class MessageViewModel
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Desc { get; set; }
        public DateTime SentDate { get; set; }
    }
}