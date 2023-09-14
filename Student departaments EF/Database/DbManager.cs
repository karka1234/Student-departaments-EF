using Microsoft.EntityFrameworkCore;
using Student_departaments_EF.Database;
using Student_departaments_EF.Database.EF;
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
        private readonly string _config = DatabaseConfig.connString;

        public static void AddDepartament(string name, string description, string address)
        {
            using var context = new DepartaentContext();
            context.DepartamentModels.Add(new DepartamentModel(name,description,address));
            context.SaveChanges();
        }
        public static void AddLecture(string name, string description)
        {
            using var context = new DepartaentContext();
            context.LectureModels.Add(new LectureModel(name,description));
            context.SaveChanges();
        }
        public static void AddStudent(string firstName, string lastName, string departamentName = null)
        {
            DepartamentModel departament = new DepartamentModel();
            using var context = new DepartaentContext();
            if (departamentName != null)
                if (context.DepartamentModels.Any(x => x.Name.ToUpper() == departamentName.ToUpper()))
                {
                    departament = context.DepartamentModels.Where(x => x.Name.ToUpper() == departamentName.ToUpper()).FirstOrDefault();
                    context.StudentModels.Add(new StudentModel(departament.Id, firstName, lastName));
                }
                else Console.WriteLine($"There is no departament with {departamentName} ID");
            else
            {
                context.StudentModels.Add(new StudentModel(firstName, lastName));
            }
            context.SaveChanges();
        }

        public static void AddLectureToDepartament(string lectureName, string departamentName)
        {
            using var context = new DepartaentContext();
            
            LectureModel lecture = context.LectureModels.FirstOrDefault(x => x.Name.ToUpper() == lectureName.ToUpper());
            DepartamentModel departament = context.DepartamentModels.FirstOrDefault(x => x.Name.ToUpper() == departamentName.ToUpper());
            if (departament != null)
            {
                if (lecture != null)
                {
                    DepartamentLectureModel model = context.DepartamentLectureModels.FirstOrDefault(x => x.DepartamentModelId == departament.Id && x.LectureModelId == lecture.Id);
                    if (model == null)
                    {
                        context.DepartamentLectureModels.Add(new DepartamentLectureModel(departament, lecture));                        
                    }
                    else Console.WriteLine($"Relation between {departament.Id} {lecture.Id} already exists");
                }
                else Console.WriteLine($"There is no lecture with {lectureName}");
            }
            context.SaveChanges();
        }


        //add lecture to student
        public static void AddLectureToStudent(string lectureName, string studentFullName)
        {
            using var context = new DepartaentContext();
            LectureModel lecture = context.LectureModels.FirstOrDefault(x => x.Name.ToUpper() == lectureName.ToUpper());            
            StudentModel student = context.StudentModels.Include(d=>d.DepartamentModel).FirstOrDefault(x => x.FullName.ToUpper() == studentFullName.ToUpper());
            DepartamentModel departament = student.DepartamentModel;
            if (departament != null)
            {
                if (lecture != null)
                {
                    if (student != null)
                    {
                        DepartamentLectureModel model = context.DepartamentLectureModels.FirstOrDefault(x => x.DepartamentModelId == departament.Id && x.LectureModelId == lecture.Id);
                        if (model == null)
                        {
                            context.LectureStudentModels.Add(new LectureStudentModel(lecture, student));
                        }
                        else Console.WriteLine($"Lecture {lectureName} not exists in Departament {departament.Name}");
                    }
                    else Console.WriteLine($"There is no student with {studentFullName}");
                }
                else Console.WriteLine($"There is no lecture with {lectureName}");
            }
            else Console.WriteLine($"Student dont have departament");
            context.SaveChanges();
        }

        public static void AddStudentToDepartament(string departamentName, string studentFullName)
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
                else Console.WriteLine($"There is no student with {studentFullName} ID");
            }
            else Console.WriteLine($"There is no departament with {departamentName} ID");
            context.SaveChanges();
        }



        public static string GetAllDepartamentsAndLectures()
        {            
            using var context = new DepartaentContext();
            var departaments = context.DepartamentModels.Include(dl => dl.DepartamentLectureModels).ThenInclude(l => l.LectureModel);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DepartamentModel departament in departaments)
            {
                stringBuilder.AppendLine(departament.GetDepartament() + " Lectures:");
                foreach (var lecture in departament.DepartamentLectureModels)
                {
                    stringBuilder.AppendLine($"\t\t{lecture.LectureModel.GetLecture()}");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

        public static string GetAllStudentsLectures()
        {
            using var context = new DepartaentContext();
            var studentLectures = context.StudentModels.Include(dl => dl.LectureStudentModels).ThenInclude(l => l.LectureModel);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Student: ");
            foreach (StudentModel student in studentLectures)
            {
                stringBuilder.AppendLine("\t" + student.GetStudent() + " Lectures:");
                foreach (var lecture in student.LectureStudentModels)
                {
                    stringBuilder.AppendLine($"\t\t{lecture.LectureModel.GetLecture()}");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
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