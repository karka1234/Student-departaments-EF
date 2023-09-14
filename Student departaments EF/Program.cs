using Student_departaments_EF.Database;

namespace Student_departaments_EF
{
    internal class Program
    {
        static void Main(string[] args)//su studentu priskyrimu poaskaitom kazkas bvlogai
        {
            Console.WriteLine("Hello, World!");
            /*
                        DbManager.AddDepartament("Departament name", "Departament description ", "Adress");
                        DbManager.AddStudent("First name", "Last name", "Existing departament name");
                        DbManager.AddLecture("Lecture name", "Lecture description");

                        DbManager.AddLectureToDepartament("Lecture name", "Existing departament name");
                        DbManager.AddLectureToStudent("Lecture name", "First name Last name"); //lecture turi egzistuoti departamante

                        */


            // Sukuriamos 3 departamentai
            DbManager.AddDepartament("Informatikos departamentas", "Čia mokomasi programavimo ir duomenų bazės valdymo", "Vilniaus g. 1");
            DbManager.AddDepartament("Matematikos departamentas", "Čia mokomasi matematikos ir statistikos", "Kauno g. 2");
            DbManager.AddDepartament("Literatūros departamentas", "Čia mokomasi literatūros ir kūrybinio rašymo", "Klaipėdos g. 3");

            // Sukuriami 10 studentų ir priskiriami atsitiktinai prie departamentų
            DbManager.AddStudent("Jonas", "Jonaitis", "Informatikos departamentas");
            DbManager.AddStudent("Petras", "Petraitis", "Informatikos departamentas");
            DbManager.AddStudent("Ona", "Onutė", "Matematikos departamentas");
            DbManager.AddStudent("Eglė", "Eglytė", "Matematikos departamentas");
            DbManager.AddStudent("Marius", "Mariukas", "Literatūros departamentas");
            DbManager.AddStudent("Rasa", "Rasutė", "Literatūros departamentas");
            DbManager.AddStudent("Tomas", "Tomaitis", "Informatikos departamentas");
            DbManager.AddStudent("Lina", "Linutė", "Matematikos departamentas");
            DbManager.AddStudent("Vytas", "Vytautas", "Literatūros departamentas");
            DbManager.AddStudent("Jurga", "Jurgutė", "Literatūros departamentas");

            // Sukuriamos 8 paskaitos
            DbManager.AddLecture("Programavimas C#", "Mokomasi C# programavimo kalbos pagrindus");
            DbManager.AddLecture("Duomenų bazės", "Mokomasi SQL ir duomenų bazės valdymo");
            DbManager.AddLecture("Algebra", "Mokomasi algebros pagrindus");
            DbManager.AddLecture("Geometrija", "Mokomasi geometrijos pagrindus");
            DbManager.AddLecture("Literatūros analizė", "Mokomasi literatūros analizės pagrindus");
            DbManager.AddLecture("Kūrybinis rašymas", "Mokomasi kūrybinio rašymo pagrindus");
            DbManager.AddLecture("Statistika", "Mokomasi statistikos pagrindus");
            DbManager.AddLecture("Tikimybių teorija", "Mokomasi tikimybių teorijos pagrindus");

            // Paskaitos priskiriamos atsitiktinai prie departamentų
            DbManager.AddLectureToDepartament("Programavimas C#", "Informatikos departamentas");
            DbManager.AddLectureToDepartament("Duomenų bazės", "Informatikos departamentas");
            DbManager.AddLectureToDepartament("Algebra", "Matematikos departamentas");
            DbManager.AddLectureToDepartament("Geometrija", "Matematikos departamentas");
            DbManager.AddLectureToDepartament("Literatūros analizė", "Literatūros departamentas");
            DbManager.AddLectureToDepartament("Kūrybinis rašymas", "Literatūros departamentas");
            DbManager.AddLectureToDepartament("Statistika", "Matematikos departamentas");
            DbManager.AddLectureToDepartament("Tikimybių teorija", "Matematikos departamentas");

            // Paskaitos priskiriamos atsitiktinai prie studentų (priklauso nuo to, kurie studentai yra kuriose paskaitose)
            DbManager.AddLectureToStudent("Programavimas C#", "Jonas Jonaitis");
            DbManager.AddLectureToStudent("Duomenų bazės", "Petras Petraitis");
            DbManager.AddLectureToStudent("Algebra", "Ona Onutė");
            DbManager.AddLectureToStudent("Geometrija", "Eglė Eglytė");
            DbManager.AddLectureToStudent("Literatūros analizė", "Marius Mariukas");
            DbManager.AddLectureToStudent("Kūrybinis rašymas", "Rasa Rasutė");


            //DbManager.AddStudentToDepartament("Departament name", "First name3 Last name");


            Console.WriteLine(DbManager.GetAllDepartamentsAndLectures());
            Console.WriteLine(DbManager.GetAllStudentsLectures());

        }
    }
}
/*
 
 Pagal šiuos aprasymus surasyk i parametru vitas belekokius sugalvotas logiskas reiksmes. Taip pat atkreipk demesi kad yra rysiai. Kur parasyta Departament name tai ten kur yra Existing departament name turi buti toks pat pavadinimas. Sukurk 3 departamentus, 10 studentu kurie priskirti departamentams atsitiktine tvarka, sukurk 8 paskaitas jas taip pat priskirk atsitiktine tvarka.             DbManager.AddDepartament("Departament name", "Departament description ", "Adress");
            DbManager.AddStudent("First name", "Last name", "Existing departament name");
            DbManager.AddLecture("Lecture name", "Lecture description");

            DbManager.AddLectureToDepartament("Lecture name", "Existing departament name");
            DbManager.AddLectureToStudent("Lecture name", "First name Last name"); //lecture turi egzistuoti departamante

 */