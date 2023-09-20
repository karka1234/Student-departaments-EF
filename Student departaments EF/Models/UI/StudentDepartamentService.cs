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
            string fullNameTemp;
            while (true)
            {                
                Console.Clear();
                Console.WriteLine(_strings.programHeader);
                Console.WriteLine(_strings.getMenu());
                selection = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (selection) 
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine(_strings.addDepartament);
                        _dbManager.AddDepartament(GetInputFromConsole(_strings.departamentName), GetInputFromConsole(_strings.description), GetInputFromConsole(_strings.address));
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine(_strings.addStudent);
                        Console.WriteLine("Enter with departament ? 1 to yes : ENTER to no");
                        if (Console.ReadKey().KeyChar == '1')
                        {
                            Console.WriteLine(_dbManager.GetAllDepartamentNames());
                            _dbManager.AddStudent(GetInputFromConsole(_strings.firstName), GetInputFromConsole(_strings.lastName), GetInputFromConsole(_strings.departamentName));
                        }
                        else
                            _dbManager.AddStudent(GetInputFromConsole(_strings.firstName), GetInputFromConsole(_strings.lastName));
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine(_strings.addLecture);
                        _dbManager.AddLecture(GetInputFromConsole(_strings.lectureName), GetInputFromConsole(_strings.description));
                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine(_dbManager.GetAllDepartamentNames());
                        Console.WriteLine(_dbManager.GetAllLectureNames());
                        Console.WriteLine(_strings.assignLectureToDepartament);
                        _dbManager.AddLectureToDepartament(GetInputFromConsole(_strings.lectureName), GetInputFromConsole(_strings.departamentName));
                        break;
                    case '5':///getinti kazkaip paskaitas kurios yra studento departamente
                        Console.Clear();
                        Console.WriteLine(_dbManager.GetAllStudentsNames());
                        fullNameTemp = $"{GetInputFromConsole(_strings.firstName)} {GetInputFromConsole(_strings.lastName)}";
                        Console.WriteLine(_dbManager.GetAllDepartamentLectureNames(fullNameTemp));
                        Console.WriteLine(_strings.assignStudentToDepartament);
                        _dbManager.AddLectureToStudent(GetInputFromConsole(_strings.lectureName), fullNameTemp);
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine(_dbManager.GetAllStudentsNames());
                        Console.WriteLine(_dbManager.GetAllDepartamentNames());
                        Console.WriteLine(_strings.addOrChangeStudentDepartament);
                        fullNameTemp = $"{GetInputFromConsole(_strings.firstName)} {GetInputFromConsole(_strings.lastName)}";
                        _dbManager.AddOrChangeStudentDepartament(GetInputFromConsole(_strings.departamentName), fullNameTemp);
                        break;
                    case '7':
                        Console.Clear();
                        Console.WriteLine(_strings.showAllDepartamentsWithLectures);
                        Console.WriteLine(_dbManager.GetAllDepartamentsAndLectures());
                        break;
                    case '8':
                        Console.Clear();
                        Console.WriteLine(_strings.showallStudentsWithLectures);
                        Console.WriteLine(_dbManager.GetAllStudentsLectures());
                        break;
                    case '9':
                        Console.Clear();

                        Console.WriteLine(_dbManager.GetAllStudentsDepartaments());
                        break;
                    default:
                        return;
                }
                Console.ReadLine();
            }

        }
        public string GetInputFromConsole(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine().TrimStart().TrimEnd();
        }
    }
}
