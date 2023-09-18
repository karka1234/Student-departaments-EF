using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Language
{
    internal interface IOutStrings
    {
        public string departamentName { get; }
        public string description { get; }
        public string address { get; }
        public string firstName { get; }
        public string lastName { get; }
        public string lectureName { get; }
        public string addDepartament { get; }
        public string addLecture { get; }
        public string addStudent { get; }
        public string addedSucesfully { get; }

        public string assignLectureToDepartament { get; }
        public string assignStudentToDepartament { get; }
        public string addOrChangeStudentDepartament { get; }

        public string programHeader { get; }

        public string showAllDepartamentsWithLectures { get; }
        public string showallStudentsWithLectures { get; }

        public string getMenu();
        public string erroNoDepartament(string departamentName);
        public string errorRelationDepLecExists(Guid departamentId, Guid lectureId);
        public string errorRelationStudLecExists(Guid student, Guid lectureId);
        public string errorNoLecture(string lectureName);
        public string errorLecNotExistsInDep(string lecName, string depName);
        public string errorNoStudent(string studentFullName);
        public string errorNoStudentDepartament();
        public string lectures { get; }
        public string students { get; }
        public string departaments { get; }
        public string studentDepratament { get; }
    }
}
