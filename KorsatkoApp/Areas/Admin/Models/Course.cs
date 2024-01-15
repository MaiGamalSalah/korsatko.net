using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KorsatkoApp.Areas.Admin.Models
{
    public class Course
    {
        [Key]
        [DisplayName("رقم الكورس ")]
        public int Id { get; set; }
        [Required]
        [DisplayName("اسم الكورس ")]
        public string Name { get; set; }
        [DisplayName("مواصفات الكورس ")]
        public string? Description { get; set; }
        [DisplayName("متطلبات الكورس ")]
        public string? Prerequisites { get; set; }
        [DisplayName("صورة الكورس ")]
        public string? Picture { get; set; }
        [DisplayName("السعر ")]
        public double Price { get; set; }
        public List<Session> Sessions { get; } = new();
        [DisplayName("إضافة ")]
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
