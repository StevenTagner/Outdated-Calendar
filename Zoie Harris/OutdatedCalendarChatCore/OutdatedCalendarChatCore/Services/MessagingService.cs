using Microsoft.EntityFrameworkCore;
using OutdatedCalendarchat.Models;
using OutdatedCalendarChatCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OutdatedCalendarChatCore.Services
{
    public class MessagingService
    {
        private readonly OutdatedCalendarContext dbContext;
        public MessagingService()
        {
            dbContext = new OutdatedCalendarContext();  
        }
        internal List<MessageViewModel> GetMessagesByPersonId(int personId)
        {
            var result = new List<MessageViewModel>();


            var receivedMessageIds = dbContext.MessageRecipients.Where(i=>i.ToPersonId == personId).Select(i=>i.MessageId).Distinct().ToList();
            var myMessages = dbContext.Messages.Include("FromPerson").Include("MessageRecipients").Where(i => i.FromPersonId == personId || receivedMessageIds.Contains(i.Id)).ToList();
            result= myMessages.Select(i => new MessageViewModel {
            Desc = i.Description,
            SentDate = i.SentDate,
            From=$"{i.FromPerson.FirstName}, {i.FromPerson.LastName}",
            To=GetToPersonList(i.MessageRecipients)
            }).ToList();

            return result;
        }

        private string GetToPersonList(ICollection<MessageRecipient> messageRecipients)
        {
            var result = string.Empty;
            if (messageRecipients !=null)
            {
                foreach (var item in messageRecipients)
                {
                    var toPerson = dbContext.People.FirstOrDefault(i => i.Id==item.ToPersonId);
                    if (toPerson != null)
                    {
                        result += $"{toPerson.FirstName} {toPerson.LastName};";

                    }
                }
            }
            return result;
        }
    }
}
