using System.ComponentModel.DataAnnotations;

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
        //public HashSet<string>? Attendees { get; set; }
        
        //public HashSet<string>? Tags { get; set; }
    }
}
