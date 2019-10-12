using System;
using System.Collections.Generic;

namespace HRM.Model.Entities.Request
{
    public class RequestType : BaseEntity
    {
        public String NameRequest { get; set; }
        public Double Percent { get; set; }
        
        public virtual ICollection<ApproveDayOff> ApproveDayOffs { get; set; }
    }
}