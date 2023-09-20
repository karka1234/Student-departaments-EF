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

        public void FillData()
        {
            /*
             * Chat gpt užklausa
             * 
            Pagal šiuos aprasymus surasyk i parametru vitas belekokius sugalvotas logiskas reiksmes. Taip pat atkreipk demesi kad yra rysiai. Kur parasyta Departament name tai ten kur yra Existing departament name turi buti toks pat pavadinimas. Sukurk 3 departamentus, 4 studentu kurie priskirti departamentams atsitiktine tvarka, sukurk 9 paskaitas jas taip pat priskirk atsitiktine tvarka kad studentas turetu bent po keleta paskaitu
            DbManager.AddDepartament("Departament name", "Departament description ", "Adress");
            DbManager.AddStudent("First name", "Last name", "Existing departament name");
            DbManager.AddLecture("Lecture name", "Lecture description");

            DbManager.AddLectureToDepartament("Lecture name", "Existing departament name");
            DbManager.AddLectureToStudent("Lecture name", "First name Last name"); //lecture turi egzistuoti departamante
            */
            // Pridedame 3 departamentus
            _dbManager.AddDepartament("Informatikos departamentas", "Departamentas skirtas IT ir programavimo mokymui", "Vilniaus g. 1");
            _dbManager.AddDepartament("Humanitarinių mokslų departamentas", "Departamentas skirtas literatūrai, filosofijai ir kalboms", "Kauno g. 2");
            _dbManager.AddDepartament("Inžinerijos departamentas", "Departamentas skirtas inžinerijos ir technologijų mokymui", "Klaipėdos g. 3");

            // Pridedame 4 studentus
            _dbManager.AddStudent("Jonas", "Jonaitis", "Informatikos departamentas");
            _dbManager.AddStudent("Petras", "Petraitis", "Humanitarinių mokslų departamentas");
            _dbManager.AddStudent("Ona", "Onutė", "Inžinerijos departamentas");
            _dbManager.AddStudent("Eglė", "Eglytė", "Informatikos departamentas");

            // Pridedame 9 paskaitas
            _dbManager.AddLecture("Programavimas C#", "Mokymai apie programavimą C# kalba");
            _dbManager.AddLecture("Literatūros analizė", "Mokymai apie literatūros analizę ir interpretaciją");
            _dbManager.AddLecture("Mechanika", "Mokymai apie inžinerinę mechaniką");

            _dbManager.AddLecture("Duomenų bazės", "Mokymai apie duomenų bazės valdymą ir SQL");
            _dbManager.AddLecture("Filosofija", "Mokymai apie filosofijos pagrindus");
            _dbManager.AddLecture("Elektronika", "Mokymai apie elektronikos pagrindus");

            _dbManager.AddLecture("Tinklai", "Mokymai apie kompiuterių tinklus");
            _dbManager.AddLecture("Istorija", "Mokymai apie pasaulio istoriją");
            _dbManager.AddLecture("Statyba", "Mokymai apie statybų inžineriją");

            // Priskiriame paskaitas departamentams
            _dbManager.AddLectureToDepartament("Programavimas C#", "Informatikos departamentas");
            _dbManager.AddLectureToDepartament("Literatūros analizė", "Humanitarinių mokslų departamentas");
            _dbManager.AddLectureToDepartament("Mechanika", "Inžinerijos departamentas");

            _dbManager.AddLectureToDepartament("Duomenų bazės", "Informatikos departamentas");
            _dbManager.AddLectureToDepartament("Filosofija", "Humanitarinių mokslų departamentas");
            _dbManager.AddLectureToDepartament("Elektronika", "Inžinerijos departamentas");
                
            _dbManager.AddLectureToDepartament("Tinklai", "Informatikos departamentas");
            _dbManager.AddLectureToDepartament("Istorija", "Humanitarinių mokslų departamentas");
            _dbManager.AddLectureToDepartament("Statyba", "Inžinerijos departamentas");

            // Priskiriame paskaitas studentams
            _dbManager.AddLectureToStudent("Programavimas C#", "Jonas Jonaitis");
            _dbManager.AddLectureToStudent("Literatūros analizė", "Petras Petraitis");
            _dbManager.AddLectureToStudent("Mechanika", "Ona Onutė");

            _dbManager.AddLectureToStudent("Duomenų bazės", "Eglė Eglytė");
            _dbManager.AddLectureToStudent("Filosofija", "Petras Petraitis");
            _dbManager.AddLectureToStudent("Elektronika", "Ona Onutė");

            _dbManager.AddLectureToStudent("Tinklai", "Jonas Jonaitis");
            _dbManager.AddLectureToStudent("Istorija", "Petras Petraitis");
            _dbManager.AddLectureToStudent("Statyba", "Ona Onutė");
        }
    }
}
