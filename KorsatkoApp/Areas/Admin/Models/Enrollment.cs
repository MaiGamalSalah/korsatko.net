using System.ComponentModel;

namespace KorsatkoApp.Areas.Admin.Models
{
    public class Enrollment
    {
        [DisplayName("ارقم التسجيل ")]
        public string EnrollmentNumber { get; set; }
        [DisplayName("رقم الطالب ")]
        public string StudentId { get; set; }
        [DisplayName("رقم المحاضرة ")]
        public int SessionId { get; set; }
        [DisplayName("حالة الدفع ")]
        public string PaymentStatus { get; set; }
        public Session? session { get; set; } = null!;  //  Reference navigation property
        public Student? student { get; set; } = null!; // Reference navigation property
        [DisplayName("اضافة ميعاد ")]
        public DateTime AddedOn { get; set; } = DateTime.Now;

    }
}
