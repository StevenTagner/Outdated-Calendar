using System;
using System.Collections.Generic;

#nullable disable

namespace OutdatedCalendarChatCore.Models
{
    public partial class EventObject
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public string Tags { get; set; }
    }
}
