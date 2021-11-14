using System;
namespace OutdatedCalendarchat.Models
{
    public class Message
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Desc { get; set; }
        public DateTime SentDate { get; set; }
    }
}