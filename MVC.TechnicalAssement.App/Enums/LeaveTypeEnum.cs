using System.ComponentModel.DataAnnotations;

namespace Logic.TechnicalAssement.App.Enums
{
    public enum LeaveTypeEnum
    {
        [Display(Name = "Annual Leave")]
        AnnualLeave,
        [Display(Name = "Sick Leave")]
        SickLeave,
        [Display(Name = "Compassionate Leave")]
        CompassionateLeave,
        [Display(Name = "Unpaid Leave")]
        UnpaidLeave,
    }
}
