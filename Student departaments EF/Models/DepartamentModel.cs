using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models
{
    [Table("DepartamentModel")]
    internal class DepartamentModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } //nurodyt kad unique
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        //student risys
        public List<StudentModel> StudentModels { get; set; } = new List<StudentModel>();
        //lecture risys
        public List<DepartamentLectureModel> DepartamentLectureModels { get; set; } = new List<DepartamentLectureModel>();
        public DepartamentModel(string name, string description, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Address = address;
        }
        public string GetDepartament()
        {
            return $"'{Name}' - '{Description}' ({Address})";
        }
        public Guid GetId()
        {
            return Id;
        }
    }
}
