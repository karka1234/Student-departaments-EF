using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models
{
    [Table("LectureModel")]
    internal class LectureModel
    {
        [Key]
        public Guid Id { get; set; }        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        //departament risys
        public List<DepartamentLectureModel> DepartamentLectureModels { get; set; } = new List<DepartamentLectureModel>();
        //student risys
        public List<LectureStudentModel> LectureStudentModels { get; set; } = new List<LectureStudentModel>();
        public LectureModel(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
        public LectureModel() { }
        public string GetLecture()
        {
            return $"'{Name}' - '{Description}' ";
        }

    }
}
