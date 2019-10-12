using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.ViewModel.Request
{
    public class ChangeShiftViewModel
    {
        public Guid Id { get; set; }

        [Required] public string SenderId { get; set; }

        [Required] public string ReceiverId { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string FactoryName { get; set; }

        [Required] public string UnitName { get; set; }


        [Required] public string OldShift { get; set; }

        [Required] public string NewShift { get; set; }

        [Required] public string Content { get; set; }
    }
}