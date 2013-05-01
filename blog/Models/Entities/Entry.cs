using System;
using System.Collections.Generic;

namespace blog.Models.Entities
{
    public class Entry : IEntity
    {
        public int EntryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}