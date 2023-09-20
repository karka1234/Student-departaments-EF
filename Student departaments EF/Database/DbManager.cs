using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Student_departaments_EF.Database;
using Student_departaments_EF.Database.EF;
using Student_departaments_EF.Language;
using Student_departaments_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Database
{
    internal class DbManager
    {
        private readonly string _config = DatabaseConfig.connString;//uzklausas vienodas unit of work
        private readonly IOutStrings _strings;
        private readonly int showLineCounterMax = 3;
        public DbManager(IOutStrings languageConfig)
        {
            _strings = languageConfig;
        }
        public static void testPrint()
        {
            Console.WriteLine();
        }
        public void AddDepartament(string name, string description, string address)
        {
            if (name == null || description == null || address == null)
                return;
            using var context = new DepartaentContext();
            context.DepartamentModels.Add(new DepartamentModel(name,description,address));
            context.SaveChanges();
        }
        public void AddLecture(string name, string description)
        {
            if (name == null || description == null)
                return;
            using var context = new DepartaentContext();
            context.LectureModels.Add(new LectureModel(name,description));
            context.SaveChanges();
        }
        public void AddStudent(string firstName, string lastName, string departamentName = null)
        {
            if (firstName == null || lastName == null)
                return;
            using var context = new DepartaentContext();
            if (departamentName != null)
            {
                DepartamentModel departament = LinqGetDepartament(departamentName, context);
                if (departament == null)
                {
                    Console.WriteLine(_strings.erroNoDepartament(departamentName));
                    return;
                }
                context.StudentModels.Add(new StudentModel(departament.Id, firstName, lastName));
            }
            else
            {
                context.StudentModels.Add(new StudentModel(firstName, lastName));
            }
            context.SaveChanges();
        }
        public void AddLectureToDepartament(string lectureName, string departamentName)
        {
            if (lectureName == null || departamentName == null)
                return;
            using var context = new DepartaentContext();
            DepartamentModel departament = LinqGetDepartament(departamentName, context);
            if (departament == null)
            {
                Console.WriteLine(_strings.erroNoDepartament(departamentName));
                return;
            }
            LectureModel lecture = LinqGetLecture(lectureName, context);
            if (lecture == null)
            {
                Console.WriteLine(_strings.errorNoLecture(lectureName));
                return;
            }
            DepartamentLectureModel model = LinqGetDepartamentLecture(context, departament, lecture);
            if (model != null)
            {
                Console.WriteLine(_strings.errorRelationDepLecExists(departament.Id, lecture.Id));
                return;
            }
            context.DepartamentLectureModels.Add(new DepartamentLectureModel(departament, lecture));
            context.SaveChanges();
        }
        public void AddLectureToStudent(string lectureName, string studentFullName)
        {
            if (lectureName == null && studentFullName == null)
                return;
            using var context = new DepartaentContext();
            StudentModel student = LinqGetStudent(studentFullName, context);
            if (student == null)
            {
                Console.WriteLine(_strings.errorNoStudent(studentFullName));
                return;
            }
            LectureModel lecture = LinqGetLecture(lectureName, context);
            if (lecture == null)
            {
                Console.WriteLine(_strings.errorNoLecture(lectureName));
                return;
            }
            DepartamentModel departament = student.DepartamentModel;
            if (departament == null)
            {
                Console.WriteLine(_strings.errorNoStudentDepartament());
                return;
            }
            DepartamentLectureModel model = LinqGetDepartamentLecture(context, departament, lecture);
            if (model == null)
            {
                Console.WriteLine(_strings.errorLecNotExistsInDep(lectureName, departament.Name));
                return;
            }
            LectureStudentModel model2 = LinqGetStudentLecture(context, student, lecture);
            if (model2 != null)
            {
                Console.WriteLine(_strings.errorRelationStudLecExists(student.Id, lecture.Id));
                return;
            }
            context.LectureStudentModels.Add(new LectureStudentModel(lecture, student));
            context.SaveChanges();
        }
        public void AddOrChangeStudentDepartament(string newDepartamentName, string studentFullName)
        {
            if (newDepartamentName == null || studentFullName == null)
                return;
            using var context = new DepartaentContext();
            DepartamentModel departament = LinqGetDepartament(newDepartamentName, context);
            if (departament == null)
            {
                Console.WriteLine(_strings.erroNoDepartament(newDepartamentName));
                return;
            }
            StudentModel student = LinqGetStudent(studentFullName, context);
            if (student == null)
            {
                Console.WriteLine(_strings.errorNoStudent(studentFullName));
                return;
            }
            List<LectureStudentModel> studentLectures = LinqGetStudentLectures(context, student);
            if (studentLectures != null)
                context.LectureStudentModels.RemoveRange(studentLectures);
            student.DepartamentModel = departament;
            context.SaveChanges();
        }
        public string GetAllDepartamentsAndLectures()
        {
            using var context = new DepartaentContext();
            IIncludableQueryable<DepartamentModel, LectureModel> departaments = LinqGetDepartamentsAndLectures(context);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DepartamentModel departament in departaments)
            {
                stringBuilder.AppendLine(departament.GetDepartament() + "\r\n " + _strings.lectures);
                foreach (var lecture in departament.DepartamentLectureModels)
                {
                    stringBuilder.AppendLine($"\t\t{lecture.LectureModel.GetLecture()}");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
        public string GetAllStudentsLectures()
        {
            using var context = new DepartaentContext();
            IIncludableQueryable<StudentModel, LectureModel> studentLectures = LinqGetStudentsAndLectures(context);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_strings.students + ": ");
            foreach (StudentModel student in studentLectures)
            {
                stringBuilder.AppendLine("\t" + student.GetStudent() + "\r\n " + _strings.lectures);
                foreach (var lecture in student.LectureStudentModels)
                {
                    stringBuilder.AppendLine($"\t\t{lecture.LectureModel.GetLecture()}");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
        public string GetAllStudentsDepartaments()
        {
            using var context = new DepartaentContext();
            IIncludableQueryable<StudentModel, DepartamentModel> studentDepartament = LinqGetAllStudentsDepartaments(context);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_strings.studentDepratament + ": ");
            foreach (StudentModel student in studentDepartament)
            {
                stringBuilder.AppendLine($" '{student.FullName}' - '{student.DepartamentModel.Name}' ");
            }
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
        public string GetAllStudentsNames()
        {
            using var context = new DepartaentContext();
            var students = context.StudentModels;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_strings.students + ": ");
            int lineCounter = showLineCounterMax;
            foreach (StudentModel student in students)
            {
                if (lineCounter >= 0)
                {
                    stringBuilder.Append($" '{student.FullName}', ");
                    lineCounter--;
                }
                else
                {
                    stringBuilder.Append("\r\n");
                    lineCounter = showLineCounterMax;
                }
            }
            stringBuilder.AppendLine("");
            return stringBuilder.ToString();
        }
        public string GetAllDepartamentNames()
        {
            using var context = new DepartaentContext();
            var departaments = context.DepartamentModels;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_strings.departaments + ": ");
            int lineCounter = showLineCounterMax;
            foreach (DepartamentModel dep in departaments)
            {
                if (lineCounter > 0)
                {
                    stringBuilder.Append($" '{dep.Name}', ");
                    lineCounter--;
                }
                else
                {
                    stringBuilder.Append("\r\n");
                    lineCounter = showLineCounterMax;
                }
            }
            stringBuilder.AppendLine("");
            return stringBuilder.ToString();
        }
        public string GetAllLectureNames()
        {
            using var context = new DepartaentContext();
            var lectures = context.LectureModels;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_strings.lectures + ": ");
            int lineCounter = showLineCounterMax;
            foreach (LectureModel lecture in lectures)
            {
                if (lineCounter > 0)
                {
                    stringBuilder.Append($" '{lecture.Name}', ");
                    lineCounter--;
                }
                else
                {
                    stringBuilder.Append("\r\n");
                    lineCounter = showLineCounterMax;
                }
            }
            stringBuilder.AppendLine("");
            return stringBuilder.ToString();
        }

        public string GetAllDepartamentLectureNames(string studentFullName)
        {
            if (studentFullName == null)
                return default;
            using var context = new DepartaentContext();
            StudentModel student = LinqGetStudent(studentFullName, context);
            if (student == null)
            {
                Console.WriteLine(_strings.errorNoStudent(studentFullName));
                return default;
            }
            DepartamentModel? departaments = LinqGetStudentDepartamentLectures(context, student);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(departaments.GetDepartament() + "\r\n " + _strings.lectures);
            foreach (var lecture in departaments.DepartamentLectureModels)
            {
                stringBuilder.AppendLine($"\t\t{lecture.LectureModel.GetLecture()}");
            }
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }

        private static DepartamentModel LinqGetDepartament(string departamentName, DepartaentContext context)
        {
            return context.DepartamentModels.FirstOrDefault(x => x.Name.ToUpper() == departamentName.ToUpper());
        }
        private static DepartamentLectureModel LinqGetDepartamentLecture(DepartaentContext context, DepartamentModel departament, LectureModel lecture)
        {
            return context.DepartamentLectureModels.FirstOrDefault(x => x.DepartamentModelId == departament.Id && x.LectureModelId == lecture.Id);
        }
        private static LectureStudentModel LinqGetStudentLecture(DepartaentContext context, StudentModel student, LectureModel lecture)
        {
            return context.LectureStudentModels.FirstOrDefault(x => x.LectureModelId == lecture.Id && x.StudentIModelId == student.Id);
        }
        private static LectureModel LinqGetLecture(string lectureName, DepartaentContext context)
        {
            return context.LectureModels.FirstOrDefault(x => x.Name.ToUpper() == lectureName.ToUpper());
        }
        private static StudentModel LinqGetStudent(string studentFullName, DepartaentContext context)
        {
            return context.StudentModels.Include(d => d.DepartamentModel).FirstOrDefault(x => x.FullName.ToUpper() == studentFullName.ToUpper());
        }
        private static List<LectureStudentModel> LinqGetStudentLectures(DepartaentContext context, StudentModel student)
        {
            return context.LectureStudentModels.Where(ls => ls.StudentIModelId == student.Id).ToList();
        }
        private static IIncludableQueryable<DepartamentModel, LectureModel> LinqGetDepartamentsAndLectures(DepartaentContext context)
        {
            return context.DepartamentModels.Include(dl => dl.DepartamentLectureModels).ThenInclude(l => l.LectureModel);
        }
        private static IIncludableQueryable<StudentModel, LectureModel> LinqGetStudentsAndLectures(DepartaentContext context)
        {
            return context.StudentModels.Include(dl => dl.LectureStudentModels).ThenInclude(l => l.LectureModel);
        }
        private static DepartamentModel? LinqGetStudentDepartamentLectures(DepartaentContext context, StudentModel student)
        {
            return context.DepartamentModels.Where(d => d.Id == student.DepartamentId).Include(dl => dl.DepartamentLectureModels).ThenInclude(l => l.LectureModel).FirstOrDefault();
        }
        private static IIncludableQueryable<StudentModel, DepartamentModel> LinqGetAllStudentsDepartaments(DepartaentContext context)
        {
            return context.StudentModels.Include(dl => dl.DepartamentModel);
        }
    }
}




/*
         public void AddStudentToDepartament(string departamentName, string studentFullName)
        {
            using var context = new DepartaentContext();
            DepartamentModel departament = context.DepartamentModels.FirstOrDefault(x => x.Name.ToUpper() == departamentName.ToUpper());
            StudentModel student = context.StudentModels.FirstOrDefault(x => x.FullName.ToUpper() == studentFullName.ToUpper());
            if (departament != null)
            {
                if (student != null)
                {
                    student.DepartamentId = departament.Id;
                }
                else Console.WriteLine(_strings.errorNoStudent(studentFullName));
            }
            else Console.WriteLine(_strings.erroNoDepartament(departamentName));
            context.SaveChanges();
        }
 */


//var query= db.Categories.Where(c=>c.Category_ID==cat_id).SelectMany(c=>Articles);
//public static void AddLectureToDepartament(string lectureName, string departamentName)
//{
//    DepartamentModel departament = new DepartamentModel();
//    LectureModel lecture = new LectureModel();
//    using var context = new DepartaentContext();
//    if (context.DepartamentModels.Any(x => x.Name.ToUpper() == departamentName.ToUpper()))
//    {
//        if (context.LectureModels.Any(x => x.Name.ToUpper() == lectureName.ToUpper()))
//        {
//            lecture = context.LectureModels.Where(x => x.Name.ToUpper() == lectureName.ToUpper()).FirstOrDefault();
//            departament = context.DepartamentModels.Where(x => x.Name.ToUpper() == departamentName.ToUpper()).FirstOrDefault();
//            if (!context.DepartamentLectureModels.Any(x => x.DepartamentModelId == departament.Id && x.LectureModelId == lecture.Id))
//            {
//                context.DepartamentLectureModels.Add(new DepartamentLectureModel(departament, lecture));
//                Console.WriteLine("Relation created");
//            }
//            else Console.WriteLine($"Relation between {departament.Id} {lecture.Id} already exists");
//        }
//        else Console.WriteLine($"There is no lecture with {lectureName} ID");
//    }
//    else Console.WriteLine($"There is no departament with {departamentName} ID");
//    context.SaveChanges();
//}

//jei reiks pakeist departamenta ir pridet najo departamento paskaitu : 
//add lecture to student
//public static void AddLectureToStudent(string departamentName, string lectureName, string studentFullName)
//{
//    using var context = new DepartaentContext();
//    LectureModel lecture = context.LectureModels.FirstOrDefault(x => x.Name.ToUpper() == lectureName.ToUpper());
//    DepartamentModel departament = context.DepartamentModels.FirstOrDefault(x => x.Name.ToUpper() == departamentName.ToUpper());
//    StudentModel student = context.StudentModels.FirstOrDefault(x => x.FullName.ToUpper() == studentFullName.ToUpper());
//    if (departament != null)
//    {
//        if (lecture != null)
//        {
//            if (student != null)
//            {
//                if (context.DepartamentLectureModels.Any(x => x.DepartamentModelId == departament.Id && x.LectureModelId == lecture.Id))
//                {
//                    context.LectureStudentModels.Add(new LectureStudentModel(lecture, student));
//                }
//                else Console.WriteLine($"Lecture {lectureName} not exists in Departament {departamentName}");
//            }
//            else Console.WriteLine($"There is no student with {studentFullName} ID");
//        }
//        else Console.WriteLine($"There is no lecture with {lectureName} ID");
//    }
//    else Console.WriteLine($"There is no departament with {departamentName} ID");
//    context.SaveChanges();
//}