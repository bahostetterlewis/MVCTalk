using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.Models.Entities
{
    public class IEntity
    {
         public DateTime CreatedOn { get; set; }
         public DateTime ModifiedOn { get; set; }
    }
}
