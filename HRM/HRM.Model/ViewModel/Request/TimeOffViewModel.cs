using System;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities;

namespace HRM.Model.ViewModel.Request
{
    public class TimeOffViewModel
    {
        [Key] public Guid Id { get; set; }

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
    }
}