using Student_departaments_EF.Database;
using Student_departaments_EF.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_departaments_EF.Models.UI
{
    internal class StudentDepartamentService : IStudentDepartamentService
    {
        private readonly IOutStrings _strings;
        private DbManager _dbManager;
        public StudentDepartamentService(IOutStrings languageConfig, DbManager dbManager) 
        {
            _strings = languageConfig;
            _dbManager = dbManager;
        }

        public void Run()
        {
            char selection;
            while(true) //spauysdint departamentus ar reikalingus sarassu konsoles apacioje
            {
                Console.Clear();
                Console.WriteLine(_strings.programHeader);
                Console.WriteLine(_strings.getMenu());
                selection = Console.ReadKey().KeyChar;
                switch (selection) //get all departaments and get all lectures pridet
                {
                    case '1':
                        Console.WriteLine(_strings.addDepartament);
                        _dbManager.AddDepartament(GetInputFromConsole(_strings.departamentName), GetInputFromConsole(_strings.description), GetInputFromConsole(_strings.address));
                        Console.WriteLine(_strings.addedSucesfully);
                        break;
                    case '2':
                        Console.WriteLine(_strings.addStudent);
                        _dbManager.AddStudent(GetInputFromConsole(_strings.firstName), GetInputFromConsole(_strings.lastName));//padaryt gal kad ir galetu sukurt su departamentu isakrto
                        Console.WriteLine(_strings.addedSucesfully);
                        break;
                    case '3':
                        Console.WriteLine(_strings.addLecture);
                        _dbManager.AddLecture(GetInputFromConsole(_strings.lectureName), GetInputFromConsole(_strings.description));
                        Console.WriteLine(_strings.addedSucesfully);
                        break;
                    case '4':
                        Console.WriteLine(_strings.assignLectureToDepartament);
                        _dbManager.AddLectureToDepartament(GetInputFromConsole(_strings.lectureName), GetInputFromConsole(_strings.departamentName));
                        Console.WriteLine(_strings.addedSucesfully);
                        break;
                    case '5':
                        Console.WriteLine(_strings.assignStudentToDepartament);
                        _dbManager.AddLectureToStudent(GetInputFromConsole(_strings.lectureName), $"{GetInputFromConsole(_strings.firstName)} {GetInputFromConsole(_strings.lastName)}");
                        Console.WriteLine(_strings.addedSucesfully);
                        break;
                    case '6':
                        Console.WriteLine(_strings.addOrChangeStudentDepartament);
                        _dbManager.AddOrChangeStudentDepartament(GetInputFromConsole(_strings.departamentName), $"{GetInputFromConsole(_strings.firstName)} {GetInputFromConsole(_strings.lastName)}");
                        Console.WriteLine(_strings.addedSucesfully);
                        break;
                    case '7':
                        Console.WriteLine(_strings.showAllDepartamentsWithLectures);
                        Console.WriteLine(_dbManager.GetAllDepartamentsAndLectures());
                        break;
                    case '8':
                        Console.WriteLine(_strings.showallStudentsWithLectures);
                        Console.WriteLine(_dbManager.GetAllStudentsLectures());
                        break;
                    default:
                        return;
                }
                Console.ReadLine();
            }

            /*            
            Console.WriteLine(DbManager.GetAllDepartamentsAndLectures());
            Console.WriteLine(DbManager.GetAllStudentsLectures());
             */
        }
        public string GetInputFromConsole(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine().TrimStart().TrimEnd();
        }
    }
}
