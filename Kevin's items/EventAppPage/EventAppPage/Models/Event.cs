using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EventAppPage.Models
{
    public class EventObject
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartTime { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Creator { get; set; }

        ///TODO: Add these once I get the HashSet Key working
        public ICollection<StringContainer>? Attendees { get; set; }

        public ICollection<StringContainer>? Tags { get; set; }
    }

    public class StringContainer
    {
        public int ? Id { get; set; }

        public string? Content { get; set; }
    }
}
