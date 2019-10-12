using System;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities;

namespace HRM.Model.ViewModel.Request
{
    public class TransferWorkViewModel
    {
        
        public Guid Id { get; set; }
        
        [Required] public Guid SendById { get; set; }

        [Required] public Guid ReceiverId { get; set; }

        [Required] public Guid UnitFrom { get; set; }

        [Required] public Guid UnitTo { get; set; }

        [Required] public string Reason { get; set; }
    }

    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";

        public NotEmptyAttribute() : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            //NotEmpty doesn't necessarily mean required
            if (value is null)
            {
                return true;
            }

            switch (value)
            {
                case Guid guid:
                    return guid != Guid.Empty;
                default:
                    return true;
            }
        }
    }
}