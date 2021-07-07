using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    public class Person: IInit, IComparable
    {
        //поля
        protected int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Возраст не может быть меньше нуля!");
                else
                    age = value;
            }
        }

        protected int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Рост не может быть меньше нуля!");
                else
                    height = value;
            }
        }

        protected int weight;
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Возраст не может быть меньше нуля!");
                else
                    weight = value;
            }
        }

        public string name;

        public static Random rnd = new Random();

        //конструкторы
        public Person()
        {
            this.name = "NoName";
            this.age = 0;
            this.height = 0;
            this.height = 0;
        }

        public Person(string name, int age, int height, int weight)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        //методы
        public void ShowSimple()
        {
            Console.WriteLine("Информация об объекте класса Person:");
            Console.WriteLine($"Имя: {this.name}; Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        virtual public void ShowVirt()
        {
            Console.WriteLine("Информация об объекте класса Person:");
            Console.WriteLine($"Имя: {this.name}; Возраст: {this.age}; Рост: {this.height}; Вес: {this.weight};");
        }

        string[] names = new string[] { "Ivanov", "Smirnov", "Petrov", "Vasyechkin", "Fhilimonov", "Belov", "Anyechkin", "Kornev" };

        //методы интерфейса
        public virtual object Init()
        {
            Person p = new Person(names[rnd.Next(0, names.Length)], rnd.Next(10, 25), rnd.Next(150, 190), rnd.Next(50, 100));
            return p;
        }

        //перегрузки
        public override string ToString()
        {
            return "Имя: " + name + " Возраст: " + age + " Вес: " + weight + " Рост: " + height;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person s = (Person)obj;
                return (this.name == s.name) && (this.age == s.Age) && (this.height == s.Height) && (this.weight == s.Weight);
            }
            return false;
        }

        public virtual int CompareTo(object obj)
        {
            if (obj is Person)
            {
                Person s = (Person)obj;
                return this.age.CompareTo(s.Age);
            }
            else
                throw new Exception();
        }
    }
}
