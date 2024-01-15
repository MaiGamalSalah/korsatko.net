using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KorsatkoApp.Areas.Admin.Models
{
    public class Session
    {
        [Key]
        [DisplayName("رقم المحاضرة ")]
        public int Id { get; set; }
        [DisplayName("تاريخ البداية ")]
        public DateTime StartDate { get; set; }
        [DisplayName("تاريخ النهاية ")]
        public DateTime EndDate { get; set; }
        [DisplayName("توقيت البداية ")]
        public DateTime startTime { get; set; }
        [DisplayName("توقيت النهاية ")]
        public DateTime EndTime { get; set; }
        [DisplayName("العنوان ")]
        public string Location { get; set; }
        [DisplayName("الحد الاقصى ")]
        public int Limit { get; set; }
        [DisplayName("هل متاح االتسجيل بميعاد المحاضرة ")]
        public bool IsAvailable { get; set; }
        [DisplayName("السعر ")]
        public float PriceRate { get; set; }
        [DisplayName("رقم الكورس ")]
        public int CourseId { get; set; }
        [DisplayName("رقم المدرب ")]
        public int InstructorId { get; set; }
        [DisplayName("اضافة ميعاد ")]
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public List<Enrollment> Enrollments { get; set; } = new(); //Reference Navigation property
        public Course? course { get; set; } = null!;//Reference Navigation property
        public Instructor? instructor { set; get; } = null!; //Reference Navigation property

    }
}