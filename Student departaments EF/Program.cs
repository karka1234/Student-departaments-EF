using Student_departaments_EF.Database;
using Student_departaments_EF.Language;
using Student_departaments_EF.Models.UI;
using System.Globalization;
using System.Text;

namespace Student_departaments_EF
{
    internal class Program
    {//regex ir guid
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            IOutStrings lang = new OutStringsEnglish();
            DbManager dbManager = new DbManager(lang);
            IStudentDepartamentService service = new StudentDepartamentService(lang, dbManager);            
            service.Run();
        }





        static void TestingMethods()
        {
            /*
            DbManager.AddDepartament("Departament name", "Departament description ", "Adress");
            DbManager.AddStudent("First name", "Last name", "Existing departament name");
            DbManager.AddLecture("Lecture name", "Lecture description");
            DbManager.AddLectureToDepartament("Lecture name", "Existing departament name");
            DbManager.AddLectureToStudent("Lecture name", "First name Last name");

            DbManager.ChangeStudentDepartament("Inžinerijos departamentas", "Jonas Jonaitis");
            
            DbManager.AddLectureToStudent("Elektronika", "Jonas Jonaitis");
            */
        }

        static void SteupDataUpload()
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
            /*
            // Pridedame 3 departamentus
            DbManager.AddDepartament("Informatikos departamentas", "Departamentas skirtas IT ir programavimo mokymui", "Vilniaus g. 1");
            DbManager.AddDepartament("Humanitarinių mokslų departamentas", "Departamentas skirtas literatūrai, filosofijai ir kalboms", "Kauno g. 2");
            DbManager.AddDepartament("Inžinerijos departamentas", "Departamentas skirtas inžinerijos ir technologijų mokymui", "Klaipėdos g. 3");

            // Pridedame 4 studentus
            DbManager.AddStudent("Jonas", "Jonaitis", "Informatikos departamentas");
            DbManager.AddStudent("Petras", "Petraitis", "Humanitarinių mokslų departamentas");
            DbManager.AddStudent("Ona", "Onutė", "Inžinerijos departamentas");
            DbManager.AddStudent("Eglė", "Eglytė", "Informatikos departamentas");

            // Pridedame 9 paskaitas
            DbManager.AddLecture("Programavimas C#", "Mokymai apie programavimą C# kalba");
            DbManager.AddLecture("Literatūros analizė", "Mokymai apie literatūros analizę ir interpretaciją");
            DbManager.AddLecture("Mechanika", "Mokymai apie inžinerinę mechaniką");

            DbManager.AddLecture("Duomenų bazės", "Mokymai apie duomenų bazės valdymą ir SQL");
            DbManager.AddLecture("Filosofija", "Mokymai apie filosofijos pagrindus");
            DbManager.AddLecture("Elektronika", "Mokymai apie elektronikos pagrindus");

            DbManager.AddLecture("Tinklai", "Mokymai apie kompiuterių tinklus");
            DbManager.AddLecture("Istorija", "Mokymai apie pasaulio istoriją");
            DbManager.AddLecture("Statyba", "Mokymai apie statybų inžineriją");

            // Priskiriame paskaitas departamentams
            DbManager.AddLectureToDepartament("Programavimas C#", "Informatikos departamentas");
            DbManager.AddLectureToDepartament("Literatūros analizė", "Humanitarinių mokslų departamentas");
            DbManager.AddLectureToDepartament("Mechanika", "Inžinerijos departamentas");

            DbManager.AddLectureToDepartament("Duomenų bazės", "Informatikos departamentas");
            DbManager.AddLectureToDepartament("Filosofija", "Humanitarinių mokslų departamentas");
            DbManager.AddLectureToDepartament("Elektronika", "Inžinerijos departamentas");

            DbManager.AddLectureToDepartament("Tinklai", "Informatikos departamentas");
            DbManager.AddLectureToDepartament("Istorija", "Humanitarinių mokslų departamentas");
            DbManager.AddLectureToDepartament("Statyba", "Inžinerijos departamentas");

            // Priskiriame paskaitas studentams
            DbManager.AddLectureToStudent("Programavimas C#", "Jonas Jonaitis");
            DbManager.AddLectureToStudent("Literatūros analizė", "Petras Petraitis");
            DbManager.AddLectureToStudent("Mechanika", "Ona Onutė");

            DbManager.AddLectureToStudent("Duomenų bazės", "Eglė Eglytė");
            DbManager.AddLectureToStudent("Filosofija", "Petras Petraitis");
            DbManager.AddLectureToStudent("Elektronika", "Ona Onutė");

            DbManager.AddLectureToStudent("Tinklai", "Jonas Jonaitis");
            DbManager.AddLectureToStudent("Istorija", "Petras Petraitis");
            DbManager.AddLectureToStudent("Statyba", "Ona Onutė");
            */
        }
    }
}





