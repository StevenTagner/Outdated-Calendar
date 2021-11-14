using System;
using System.Collections.Generic;

#nullable disable

namespace OutdatedCalendarChatCore.Models
{
    public partial class Person
    {
        public Person()
        {
            MessageRecipients = new HashSet<MessageRecipient>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
