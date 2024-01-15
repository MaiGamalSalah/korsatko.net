using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KorsatkoApp.Areas.Admin.Models
{
    public class Instructor
    {
        [Key]
        [DisplayName("رقم المدرب ")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The FullName is Required")]
        [DisplayName("الاسم بالكامل ")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("الايميل ")]
        public string Email { get; set; }
        [DisplayName("الجنس ")]
        public char Gender { get; set; }
        [DisplayName("رقم التليفون ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "National ID  is required")]
        [DisplayName("الرقم القومى ")]
        public string NationalId { get; set; }
        [DisplayName("سنوات الخبرة ")]
        public int ExperienceYears { get; set; }
        [DisplayName("المؤهلات ")]
        public string? Qualifications { get; set; }
        public List<Session> Sessions { get; set; } = new();

    }
}