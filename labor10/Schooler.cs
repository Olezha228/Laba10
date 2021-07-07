using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    public class Schooler : Person, IInit, IComparable
    {
        private int schoolYear;
        public int SchoolYear
        {
            get { return schoolYear; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Класс не может быть отрицательным!");
                else if (value > 11)
                    Console.WriteLine("класс не бывает больше 11!");
                else
                    schoolYear = value;
            }
        }

        private int schoolNumber;
        public int SchoolNumber
        {
            get { return schoolNumber; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Номер школы не может быть отрицательным!");
                else
                    schoolNumber = value;
            }
        }

        public static Random rand = new Random();

        public Schooler() : base()
        {
            this.schoolYear = 0;
            this.name = "NoName";
            this.schoolNumber = 0;
        }

        public Schooler(int age, int height, int weight, int year, string name, int schoolNumber)
            : base(name, age, height, weight)
        {
            this.schoolYear = year;
            this.schoolNumber = schoolNumber;
        }

        //методы
        public new void ShowSimple()
        {
            Console.WriteLine("Информация об объекте класса Schooler:");
            Console.WriteLine($"Имя: {this.name}; Класс: {this.schoolYear}; Школа: №{this.schoolNumber}; " +
                $"Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        public override void ShowVirt()
        {
            Console.WriteLine("Информация об объекте класса Schooler:");
            Console.WriteLine($"Имя: {this.name}; Класс: {this.schoolYear}; Школа: №{this.schoolNumber}; " +
                $"Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        //от интерфейса
        public override object Init()
        {
            Person p = (Person)base.Init();
            string[] names = new string[] { "Ivanov", "Smirnov", "Petrov", "Vasyechkin", "Fhilimonov", "Belov", "Anyechkin", "Kornev" };
            string[] lastNames = new string[] { "A.", "J.", "P.", "M.", "B.", "R.", "G.", "E.", "N.", "O." };
            int[] schools = new int[] { 133, 135 };
            Schooler sch = new Schooler(p.Age, p.Height, p.Weight, rand.Next(1, 12),
                names[rand.Next(0, names.Length)] + " " + lastNames[rand.Next(0, names.Length)], 
                schools[rand.Next(0, 2)]);
            return sch;
        }

        //перегрузки
        public override string ToString()
        {
            return name + " из школы № " + schoolNumber + " класса " + schoolYear + " ростом " + height;
        }

        public override bool Equals(object obj)
        {
            if (obj is Schooler)
            {
                Schooler s = (Schooler)obj;
                return (this.age == s.Age) && (this.height == s.Height) && (this.weight == s.Weight) && (this.schoolYear == s.SchoolYear)
                    && (this.name == s.name) && (this.schoolNumber == s.SchoolNumber);
            }
            return false;
        }

        public override int CompareTo(object obj)
        {
            if (obj is Schooler)
            {
                Schooler s = (Schooler)obj;
                return this.name.CompareTo(s.name);
            }
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
