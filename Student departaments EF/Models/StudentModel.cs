using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models
{
    [Table("StudentModel")]
    internal class StudentModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }



        [ForeignKey("Departament")]
        public Guid DepartamentId { get; set; }
        public DepartamentModel DepartamentModel { get; set; }



        public List<LectureStudentModel> LectureStudentModels { get; set; } = new List<LectureStudentModel>();

        




    }
}
