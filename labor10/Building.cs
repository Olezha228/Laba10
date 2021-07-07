using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    public class Building : IInit, ICloneable
    {
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value > 2021)
                    year = 2021;
                else if (value < 0)
                    year = 0;
                else
                    year = value;
            }
        }

        public string name;

        public Passport pas;

        static Random rnd = new Random(); 

        private int countFloors;
        public int CountFloors
        {
            get
            {
                return countFloors;
            }
            set
            {
                if (value <= 0)
                    countFloors = 1;
                else
                    countFloors = value;
            }
        }

        //конструкторы
        public Building()
        {
            this.year = 1;
            this.name = "NoName";
            this.countFloors = 1;
            this.pas = new Passport(rnd.Next(1000, 10000));
        }

        public Building(int year, string name, int floors, int num)
        {
            this.year = year;
            this.name = name;
            this.countFloors = floors;
            this.pas = new Passport(num);
        }

        public object Init()
        {
            string[] names = new string[] { "Tower", "Castle", "House", "Residence", "Apartment", "Shack", "Bungalow" };
            string[] lastNames = new string[] { "A.", "J.", "P.", "M.", "B.", "R.", "G.", "E.", "N.", "O." };
            Building b = new Building(rnd.Next(1, 2022), names[rnd.Next(0, names.Length)] + " " + lastNames[rnd.Next(0, names.Length)],
                rnd.Next(1, 101), rnd.Next(1000, 10000));
            return b;

        }

        public override string ToString()
        {
            return this.name + ", год постройки: " + this.year + ", количество этажей: " + this.countFloors + " Паспорт: " + this.pas.sery;
        }

        public override bool Equals(object obj)
        {
            if (obj is Building)
            {
                Building s = (Building)obj;
                return (this.year == s.Year) && (this.name == s.name);
            }
            return false;
        }

        //клонирование
        public object Clone()
        {
            return new Building(this.year, this.name, this.countFloors, this.pas.sery);
        }

        //поверхностное копирование
        public object SwallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
