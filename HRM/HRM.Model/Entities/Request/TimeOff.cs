using System;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HRM.Model.Entities.Request
{
    public class TimeOff : BaseEntity
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        [Required] public string Title { get; set; }

        [Required] public Boolean IsAllDay { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required] public string Content { get; set; }

        public virtual Employee Sender { get; set; }
        public virtual Employee Receiver { get; set; }
        public virtual ApproveDayOff ApproveDayOff { get; set; }
    }
}