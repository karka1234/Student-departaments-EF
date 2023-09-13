using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models
{
    [Table("DepartamentLectureModel")]
    internal class DepartamentLectureModel
    {
        public Guid DepartamentModelId { get; set; }
        public Guid LectureModelId { get; set; }

        public DepartamentModel DepartamentModel { get; set; } = new DepartamentModel();
        public LectureModel LectureModel { get; set; } = new LectureModel();

    }
}
