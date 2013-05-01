using System;
using System.Collections.Generic;

namespace blog.Models.Entities
{
    public class Entry
    {
        public int EntryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}