using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models
{
    internal class LectureStudentModel
    {
        public Guid LectureModelId { get; set; }
        public Guid StudentIModelId { get; set; }
        public LectureModel LectureModel { get; set; }
        public StudentModel StudentModel { get; set; }
    }
}
