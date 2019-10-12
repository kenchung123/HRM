using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.Model.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? LastModified { get; set; }
        bool IsDelete { get; set; }
    }

    public class BaseEntity : IEntity
    {
        [Key] public System.Guid Id { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? OwnerId { get; set; }
        public bool IsDelete { get; set; }
        public int? Flags { get; set; }
    }
}