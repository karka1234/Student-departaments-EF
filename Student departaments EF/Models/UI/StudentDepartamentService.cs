using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models.UI
{
    internal class StudentDepartamentService : IStudentDepartamentService
    {
        public void Run()
        {
            char selection;
            while(true) 
            {
                Console.Clear();
                PrintHeader();
                PrintMenu();
            }

            /*
             

            Console.WriteLine(DbManager.GetAllDepartamentsAndLectures());
            Console.WriteLine(DbManager.GetAllStudentsLectures());
             */
            throw new NotImplementedException();
        }

        public void PrintHeader()
        {
            Console.WriteLine("Student Departament");
        }

        public void PrintMenu()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Add departament");
            sb.AppendLine("2. Add student");
        }
    }
}
