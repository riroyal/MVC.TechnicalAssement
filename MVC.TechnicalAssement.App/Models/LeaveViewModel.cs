using Logic.TechnicalAssement.App.Enums;
using System.ComponentModel.DataAnnotations;

namespace Logic.TechnicalAssement.App.Models
{
    public class LeaveViewModel
    {
        public int Id { get; set; }
        public LeaveTypeEnum LeaveType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsHalfDay {  get; set; } = true;
    }
}
