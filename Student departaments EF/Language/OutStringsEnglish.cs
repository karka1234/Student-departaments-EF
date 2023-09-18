using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Language
{
    internal class OutStringsEnglish : IOutStrings
    {
        public string departamentName { get; } = "Enter departament name";
        public string description { get; } = "Enter description";
        public string address { get; } = "Enter address";
        public string firstName { get; } = "Enter first name";
        public string lastName { get; } = "Enter last name";
        public string lectureName { get; } = "Enter lecture name";
        public string addDepartament { get; } = "Add departament";
        public string addLecture { get; } = "Add lecture";
        public string addStudent { get; } = "Add student";
        public string addedSucesfully { get; } = "Added sucesfully";

        public string assignLectureToDepartament { get; } = "Assign lecture to departament";
        public string assignStudentToDepartament { get; } = "Assign student to departament lectures";
        public string addOrChangeStudentDepartament { get; } = "Add or Change student departament";

        public string programHeader { get; } = "Student Departament";

        public string showAllDepartamentsWithLectures { get; } = "Show all departaments with lectures";

        public string showallStudentsWithLectures { get; } = "Show all students with lectures";
        public string showallStudentsDepartaments { get; } = "Show all students departaments";

        public string getMenu()
        {
            StringBuilder sb = new StringBuilder();//iskelti i virsu ir kaskarto buildint builderi ir tada isvest
            sb.AppendLine("1. " + addDepartament);
            sb.AppendLine("2. " + addStudent);
            sb.AppendLine("3. " + addLecture);
            sb.AppendLine("4. " + assignLectureToDepartament);
            sb.AppendLine("5. " + assignStudentToDepartament);
            sb.AppendLine("6. " + addOrChangeStudentDepartament);
            sb.AppendLine("7. " + showAllDepartamentsWithLectures);
            sb.AppendLine("8. " + showallStudentsWithLectures);
            sb.AppendLine("9. " + showallStudentsDepartaments);
            return sb.ToString();
        }

        public string erroNoDepartament(string departamentName)
        {
            return $"There is no departament {departamentName}";
        }

        public string errorRelationDepLecExists(Guid departamentId, Guid lectureId)
        {
            return $"Relation between {departamentId} {lectureId} already exists";
        }
        public string errorRelationStudLecExists(Guid student, Guid lectureId)
        {
            return $"Relation between {student} {lectureId} already exists";
        }
        public string errorNoLecture(string lectureName)
        {
            return $"There is no lecture {lectureName}";
        }

        public string errorLecNotExistsInDep(string lecName, string depName)
        {
            return $"Lecture {lecName} not exists in Departament {depName}";
        }
        public string errorNoStudent(string studentFullName)
        {
            return $"There is no student with {studentFullName}";
        }
        public string errorNoStudentDepartament()
        {
            return $"Student dont have departament";
        }
        public string lectures { get; } = "Lectures";
        public string students { get; } = "Students";
        public string departaments { get; } = "Departaments";
        public string studentDepratament { get; } = "Students and Departaments";
    }
}
