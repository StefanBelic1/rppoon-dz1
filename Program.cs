using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Program;




    public class Osoba
    {
        public string name { get;  set; }
        public string surname;
        public int id;

        public Osoba(string name, string surname, int id)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
        }
    }

    public class Student : Osoba
    {
        public List<int> grades { get; set; }
        public int razred { get; set; }

        public Student(string name, string surname, int id, int razred) : base(name,surname,id)
        {
            grades = new List<int>();
            this.razred = razred;
        }

        public void AddGrade(int grade)
        {
            grades.Add(grade);
        }
        public void ShowGrades()
        {
            Console.WriteLine($"Ocjene studenta {name} {surname}: {string.Join(", ", grades)}");
        }

    }

    public class Teacher: Osoba
    {
        public List<string> predmeti { get; set; }

        public Teacher(string name, string surname, int id, List<string> predmeti) : base(name, surname, id)
        {
            this.predmeti = predmeti;
        }

        public void AddGradeToStudent(Student student, int ocjena)
        {
            student.AddGrade(ocjena);
        }

        public void ShowStudentGrade(Student student)
        {
            student.ShowGrades();
        }

        public void ShowRazredGrade(List<Student> razred)
        {
            foreach (var student in razred)
            {
                ShowStudentGrade(student);
            }
        }
    }


    public class Ravnatelj : Osoba
    {
        public List<Teacher> teachers { get; set; }
        public List<Student> students { get; set; }

        public Ravnatelj(string name, string surname, int id) : base(name, surname, id)
        {
            teachers = new List<Teacher>();
            students = new List<Student>();
        }

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            teachers.Remove(teacher);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public void PregledOpćihOcjenaSkole()
        {
            foreach (var student in students)
            {
                student.ShowGrades();
            }
        }
    }


    public class Razred
    {
        public string RazredName { get; set; }
        public List<Student> students { get; set; }

        public Razred(string RazredName)
        {
            this.RazredName=RazredName;
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public void ShowRazredGrades()
        {
            foreach (var student in students)
            {
                student.ShowGrades();
            }
        }
    }
class Program
{
    static void Main(string[] args)
    {
        Ravnatelj ravnatelj = new Ravnatelj("Zdravko", "Zdravkic", 321);

        Student student = new Student("Tomi", "Mikic", 462,3);
        ravnatelj.AddStudent(student);

        Teacher teacher = new Teacher("Milan", "Milanic", 456, new List<string> { "njemacki", "engleski" });
        ravnatelj.AddTeacher(teacher);

        Razred razred = new Razred("dobarrazred");
        razred.AddStudent(student);
        teacher.AddGradeToStudent(student,3);
        ravnatelj.PregledOpćihOcjenaSkole();
        teacher.ShowRazredGrade(razred.students);
    }
}
