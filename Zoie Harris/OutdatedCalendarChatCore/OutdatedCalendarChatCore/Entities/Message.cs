using System;
using System.Collections.Generic;

#nullable disable

namespace OutdatedCalendarChatCore.Entities
{
    public partial class Message
    {
        public Message()
        {
            MessageRecipients = new HashSet<MessageRecipient>();
        }

        public int Id { get; set; }
        public int FromPersonId { get; set; }
        public string Description { get; set; }
        public DateTime SentDate { get; set; }

        public virtual Person FromPerson { get; set; }
        public virtual ICollection<MessageRecipient> MessageRecipients { get; set; }
    }
}
