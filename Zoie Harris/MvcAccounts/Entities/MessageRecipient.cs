using System;
using System.Collections.Generic;

#nullable disable

namespace MvcAccounts.Entities
{
    public partial class MessageRecipient
    {
        public int MessageId { get; set; }
        public int ToPersonId { get; set; }

        public virtual Message Message { get; set; }
        public virtual Person ToPerson { get; set; }
    }
}
