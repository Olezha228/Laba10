using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    public class Student : Person, IInit, IComparable
    {
        private int course;
        public int Course
        {
            get { return course; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Номер курса не может быть отрицательным!");
                else if (value > 5) 
                    Console.WriteLine("Номер курса не бывает больше 5!");
                else
                    course = value;
            }
        }

        private int scholarship;
        public int Scholarship
        {
            get { return scholarship; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Размер стипендии не может быть отрицательным!");
                else
                    scholarship = value;
            }
        }

        public string universityName;

        public static Random rand = new Random();

        public Student() : base()
        {
            this.course = 0;
            this.name = "NoName";
            this.universityName = "nameless University";
            this.scholarship = 0;
        }

        public Student(int age, int height, int weight, int course, string name, string universityName, int scholarship) 
            : base(name, age, height, weight)
        {
            this.course = course;
            this.name = name;
            this.universityName = universityName;
            this.scholarship = scholarship;
        }

        //методы
        public new void ShowSimple()
        {
            Console.WriteLine("Информация об объекте класса Student:");
            Console.WriteLine($"Имя: {this.name}; Курс: {this.course}; Университет: {this.universityName}; " +
                $"Стипендия: {scholarship}; Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        override public void ShowVirt()
        {
            Console.WriteLine("Информация об объекте класса Student:");
            Console.WriteLine($"Имя: {this.name}; Курс: {this.course}; Университет: {this.universityName}; " +
                $"Стипендия: {scholarship}; Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        //от интерфейса
        public override object Init()
        {
            Person p = (Person)base.Init();
            string[] names = new string[] { "Ivanov", "Smirnov", "Petrov", "Vasyechkin", "Fhilimonov", "Belov", "Anyechkin", "Kornev" };
            string[] universities = new string[] { "HSE", "PSU" };
            string[] lastNames = new string[] { "A.", "J.", "P.", "M.", "B.", "R.", "G.", "E.", "N.", "O." };
            Student stud = new Student(p.Age, p.Height, p.Weight, rand.Next(1, 5), 
                names[rand.Next(0, names.Length)] + " " + lastNames[rand.Next(0, names.Length)],
                universities[rand.Next(0, universities.Length)], rand.Next(1700, 45000));
            return stud;
        }

        //перегрузки
        public override string ToString()
        {
            return name + " " + age + " лет весом " + weight + "кг из " + universityName + " с " + course +" курса имеет стипендию равную " + scholarship;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student s = (Student)obj;
                return (this.age == s.Age) && (this.height == s.Height) && (this.weight == s.Weight) && (this.course == s.Course)
                    && (this.name == s.name) && (this.universityName == s.universityName) && (this.scholarship == s.Scholarship);
            }
            return false;
        }

        public override int CompareTo(object obj)
        {
            if (obj is Student)
            {
                Student s = (Student)obj;
                return this.name.CompareTo(s.name);
            }
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}