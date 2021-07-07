using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    public class CorrespondenceStudent : Student, IInit, IComparable
    {

        private int priceOfStudying;
        public int PriceOfStudying
        {
            get { return priceOfStudying; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Цена обучения не может быть отрицательной!");
                else
                    priceOfStudying = value;
            }
        }

        public static Random rand = new Random();

        public CorrespondenceStudent() : base()
        {
            this.priceOfStudying = 0;
        }

        public CorrespondenceStudent(int age, int height, int weight, int course, string name, 
            string universityName, int price, int scholarship)
            : base(age, height, weight, course, name, universityName, scholarship)
        {
            this.priceOfStudying = price;
        }

        //методы
        public new void ShowSimple()
        {
            Console.WriteLine("Информация об объекте класса CorrespondenceStudent:");
            Console.WriteLine($"Имя: {this.name}; Курс: {this.Course}; Университет: {this.universityName}; " +
                $"Цена обучения: {this.priceOfStudying}; Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        override public void ShowVirt()
        {
            Console.WriteLine("Информация об объекте класса CorrespondenceStudent:");
            Console.WriteLine($"Имя: {this.name}; Курс: {this.Course}; Университет: {this.universityName}; " +
                $"Цена обучения: {this.priceOfStudying}; Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        //от интерфейса
        public override object Init()
        {
            Person p = (Person)base.Init();
            string[] names = new string[] { "Smith", "John", "Peterson", "McCourty", "Brady", "Brown", "Gronkowski", "Evans", "Arians", "Godwin" };
            string[] lastNames = new string[] { "A.", "J.", "P.", "M.", "B.", "R.", "G.", "E.", "N.", "O." };
            string[] universities = new string[] { "HSE", "PSU" };
            CorrespondenceStudent corrStud = new CorrespondenceStudent(p.Age, p.Height, p.Weight, rand.Next(1, 5), 
                names[rand.Next(0, names.Length)] + " " + lastNames[rand.Next(0, names.Length)],
                universities[rand.Next(0, universities.Length)], rand.Next(80000, 120001), 0);
            return corrStud;
        }

        //перегрузки
        public override string ToString()
        {
            return name + " из " + universityName + " весом " + weight + "кг с " + Course + " курса платит за учебу " + priceOfStudying;
        }

        public override bool Equals(object obj)
        {
            if (obj is CorrespondenceStudent)
            {
                CorrespondenceStudent s = (CorrespondenceStudent)obj;
                return (this.age == s.Age) && (this.height == s.Height) && (this.weight == s.Weight) && (this.Course == s.Course)
                    && (this.name == s.name) && (this.universityName == s.universityName) && (this.priceOfStudying == s.PriceOfStudying)
                    && (this.Scholarship == s.Scholarship);
            }
            return false;
        }

        public override int CompareTo(object obj)
        {
            if (obj is CorrespondenceStudent)
            {
                CorrespondenceStudent s = (CorrespondenceStudent)obj;
                return this.name.CompareTo(s.name);
            }
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
