using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KorsatkoApp.Areas.Admin.Models
{
    public class Student : IdentityUser
    {
        [Required(ErrorMessage = "The FullName is Required")]
        [DisplayName("الاسم بالكامل ")]
        public string FullName { get; set; }
        [DisplayName("النوع")]
        public char Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("تاريخ الميلاد ")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("الرقم القومى ")]
        public string NationalId { get; set; }
        [DisplayName("اضافة ميعاد ")]
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
