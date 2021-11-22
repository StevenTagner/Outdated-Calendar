﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EventAppPage.Models
{
    public class EventObject
    {
        static int testID = 1;
        public EventObject()
        {
            
            if(Tags == null)
            {
                Tags = new TestCollection();
            }
            //Tags.Add(s);
            StringContainer test = new StringContainer();
            test.Content = "Item " + testID++.ToString();
            Tags.Add(test);

            StringContainer test2 = new StringContainer();
            test2.Content = "Item " + testID++.ToString();
            Tags.Add(test2);

        }
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartTime { get; set; }
        
        
        ///NOTE: EndTime is present but does nothing. It is only here because the database will not update otherwise.
        [DataType(DataType.Date)]
        public DateTime? EndTime { get; set; }
        
        public int? Duration { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Creator { get; set; }
        public ICollection<StringContainer>? Tags { get; set; }

        
        ///TODO: Add these once I get the HashSet Key working
        //public ICollection<StringContainer>? Attendees { get; set; }


    }

    public partial class StringContainer
    {
        public int ? Id { get; set; }

        public string? Content { get; set; }

        public override string ToString()
        {
            if(Content == null)
            {
                return string.Empty;
            }
            return Content;
        }
    }

    public partial class TestCollection : HashSet<StringContainer>
    {
        public override string ToString()
        {
            string Output = "";
            foreach(StringContainer item in this)
            {
                Output = Output + item.ToString() + ", ";
            }
            return Output;
        }
        
    }
}
