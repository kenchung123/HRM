using System;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities.Employees;

namespace HRM.Model.Entities.Request
{
    public class TransferWork : BaseEntity
    {
        [Required] public Guid SendById { get; set; }

        [Required] public Guid ReceiverId { get; set; }

        [Required] public Guid UnitFrom { get; set; }

        [Required] public Guid UnitTo { get; set; }

        [Required] public string Reason { get; set; }
        
        public virtual Employee Sender { get; set; }
        public virtual Employee Receiver { get; set; }
        public virtual Unit.Unit OldUnit { get; set; }
        public virtual Unit.Unit NewUnit { get; set; }
    }
}