using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor10
{
    class Program
    {
        static int ParseInt(string input)
        {
            int n;
            bool ok;
            Console.Write(input);
            do
            {
                string str = Console.ReadLine();
                ok = int.TryParse(str, out n);
                if (!ok)
                    Console.WriteLine("Число должно быть целым!");
            }
            while (!ok);
            return n;
        }

        static double ParseDouble(string input)
        {
            double n;
            bool ok;
            Console.WriteLine(input);
            do
            {
                string str = Console.ReadLine();
                ok = double.TryParse(str, out n);
                if (!ok)
                    Console.WriteLine("Число должно быть целым!");
            }
            while (!ok);
            return n;
        }

        //часть 2
        static void Menu()
        {
            Console.WriteLine("             Меню запросов");
            Console.WriteLine("1. Количество учащихся в 133 школе.");
            Console.WriteLine("2. Суммарная стипендия всех студентов в университете HSE.");
            Console.WriteLine("3. Количество студентов-заочников на 3 курсе в университете PSU.");
            Console.WriteLine("4. Средний рост всех учащихся в 135 школе.");
            Console.WriteLine("5. Максимальная цена обучения в университете PSU.");
            Console.WriteLine("6. Минимальный возраст студента университета HSE.");
            Console.WriteLine("7. Средний вес студентов-заочников в университете PSU.");
            Console.WriteLine("8. Переход к части №3.");
        }

        static void Output1()
        {
            Console.WriteLine("Этот раздел посвящен демонстрации работы виртуальных методов в наследовании классов.\n" +
                "(В дальнейшем, чтобы перейти к следующему шагу, нажмите пробел).");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("<> Создадим 4 объекта: базовый(Person) и 3 производных(Student, Schooler, CorrespondenceStudent).");

        }

        static void Output2()
        {
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("<> Также создадим массив объектов типа Person и добавим в него все наши 4 объекта.");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("<> Через foreach вызовем НЕПЕРЕОПРЕДЕЛЕННЫЙ(невиртуальный) метод ShowSimple() для каждого объекта:");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void Output3()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Вывод: когда вызывается невиртуальный метод, то для каждого объекта нашего массива типа Person[]\n" +
                "вызывается метод ShowSimple() базового класса Person.");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("<> Через foreach вызовем ПЕРЕОПРЕДЕЛЕННЫЙ(виртуальный) метод ShowVirt():");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void Output4()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Вывод: когда вызывается виртуальный метод, то для каждого объекта нашего массива типа Person[]\n" +
                "вызывается метод ShowVirt() соответствующего класса определенного объекта нашего массива.\n\n");

            Console.Write("Нажмите любую клавишу, чтобы перейти к части №2... ");
            Console.ReadKey();
        }

        static int CountSchoolesIn133School(IInit[] arr)
        {
            int numberOfSchool = 133;
            int count = 0;
            foreach(IInit p in arr)
            {
                if (p is Schooler)
                {
                    Schooler sch = (Schooler)p;
                    if (sch.SchoolNumber == numberOfSchool)
                        count++;
                }
            }
            Console.WriteLine($"В 133 школе учатся {count} детей.");
            return count;
        }

        static int AmountScholarshipInHSE(IInit[] arr)
        {
            string university = "HSE";
            int count = 0;
            foreach (IInit p in arr)
            {
                if (p is Student)
                {
                    Student stud = (Student)p;
                    if (Equals(university, stud.universityName))
                        count += stud.Scholarship;
                }
            }
            Console.WriteLine($"В университете HSE студенты суммарно получают стипендию, равную {count}.");
            return count;
        }

        static int CorrespStudOf3CourseInPSU(IInit[] arr)
        {
            string university = "PSU";
            int count = 0;
            foreach (IInit p in arr)
            {
                if (p is CorrespondenceStudent)
                {
                    CorrespondenceStudent corrStud = (CorrespondenceStudent)p;
                    if ((corrStud.universityName == university) && (corrStud.Course == 3))
                        count++;
                }
            }
            Console.WriteLine($"В университете PSU количество 3-курсников равно {count}.");
            return count;
        }

        static int AverageHeightIn135School(IInit[] arr)
        {
            int numberOfSchool = 135;
            int count = 0;
            int commonHeight = 0;
            foreach (IInit p in arr)
            {
                if (p is Schooler)
                {
                    Schooler sch = (Schooler)p;
                    if (sch.SchoolNumber == numberOfSchool)
                    {
                        commonHeight += sch.Height;
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"В 135 школе не нашлось учеников.");
                return 0;
            }
            else
            {
                Console.WriteLine($"В 135 школе средний рост учеников = {commonHeight / count}.");
                return commonHeight / count;
            }
        }

        static int MaxPriceOfEducatInPSU(IInit[] arr)
        {
            string university = "PSU";
            int max = -1;
            foreach (IInit p in arr)
            {
                if (p is CorrespondenceStudent)
                {
                    CorrespondenceStudent stud = (CorrespondenceStudent)p;
                    if (Equals(university, stud.universityName))
                    {
                        if (stud.PriceOfStudying > max)
                            max = stud.PriceOfStudying;
                    }
                }
            }
            if (max == -1)
            {
                Console.WriteLine("В университете PSU не нашлось студентов-заочников.");
                return 0;
            }
            else
            {
                Console.WriteLine($"В университете PSU максимальная цена обучения = {max}.");
                return max;
            }
        }

        static int MinStudAgeInHSE(IInit[] arr)
        {
            string university = "HSE";
            int min = int.MaxValue;
            foreach (IInit p in arr)
            {
                if (p is Student)
                {
                    Student stud = (Student)p;
                    if (Equals(university, stud.universityName))
                        if (stud.Age < min)
                            min = stud.Age;
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("В HSE не нашлось студентов.");
                return 0;
            }
            else
            {
                Console.WriteLine($"Возраст самого молодого студента в HSE {min}.");
                return min;
            }
        }

        static int AverageWeightStudInPSU(IInit[] arr)
        {
            string university = "PSU";
            int count = 0;
            int commonWeight = 0;
            foreach (IInit p in arr)
            {
                if (p is CorrespondenceStudent)
                {
                    CorrespondenceStudent corrStud = (CorrespondenceStudent)p;
                    if (corrStud.universityName == university)
                    {
                        commonWeight += corrStud.Weight;
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("В PSU не нашлось студентов.");
                return 0;
            }
            else
            {
                Console.WriteLine($"Средний вес студента в PSU {commonWeight / count}.");
                return commonWeight / count;
            };
        }

        static void DemonstrCloneAndCopy()
        {
            Building s1 = new Building();
            s1 = (Building)s1.Init();

            Console.WriteLine("Попробуем разобраться в разнице между копированием и клонированием!"); 
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("1.1 Создадим объект типа Building: ");
            Console.WriteLine("<> Оригинал: " + s1);

            Console.WriteLine("1.2 После клонирования(в клоне мы изменили имя и паспорт): ");
            Building clone = (Building)s1.Clone();
            clone.name = "Clone" + clone.name;
            clone.pas.sery = 5555;
            Console.WriteLine("<> Оригинал: " + s1);
            Console.WriteLine("<> Клон: " + clone);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Вывод: Когда мы что-то меняем у клона, то в оригинале это не меняется(даже если это ссылочный тип)," +
                "\n - в этом суть глубокого клонирования.");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            Building b1 = new Building();
            b1 = (Building)b1.Init();
            Console.WriteLine("2.1 Создадим объект типа Building: ");
            Console.WriteLine("<> Оригинал: " + b1);

            Console.WriteLine("2.2 После копирования(в копии мы изменили имя и паспорт): ");
            Building copy = (Building)b1.SwallowCopy();
            copy.name = "Clone" + copy.name;
            copy.pas.sery = 7777;
            Console.WriteLine("<> Оригинал: " + b1);
            Console.WriteLine("<> Клон: " + copy);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Вывод: Когда мы меняем у копии поле ссылочного типа, то и в оригинале это поле так же меняется\n" +
                " - в этом суть поверхностного копирования.");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }

        static IInit[] CreateRandomArray()
        {
            IInit[] arr2 = new IInit[30];
            for (int i = 0; i < 30; i++)
            {
                if (i < 10)
                {
                    Student stud = new Student();
                    stud = (Student)stud.Init();
                    arr2[i] = stud;
                }
                else if (i < 20)
                {
                    CorrespondenceStudent corStud = new CorrespondenceStudent();
                    corStud = (CorrespondenceStudent)corStud.Init();
                    arr2[i] = corStud;
                }
                else if (i < 30)
                {
                    Schooler sch = new Schooler();
                    sch = (Schooler)sch.Init();
                    arr2[i] = sch;
                }
            }
            return arr2;
        }

        static void OutputIInitArray(IInit[] arr2)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            for (int j = 0; j < arr2.Length; j++)
            {
                if (j == 10) Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                if (j == 20) Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{j + 1}) {arr2[j]}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }

        static void BinarySearchDemonstr()
        {
            Schooler[] arrStud = new Schooler[7];
            for (int i = 0; i < 7; i++)
            {
                Schooler s = new Schooler();
                arrStud[i] = (Schooler)s.Init();
            }

            Console.WriteLine("\nМассив элементов типа Schooler:");
            for(int i = 0; i < arrStud.Length; i++)
                Console.WriteLine($"{i+1})" + arrStud[i]);

            Array.Sort(arrStud);


            Console.WriteLine("\nОтсортированный массив элементов типа Schooler:");

            for (int i = 0; i < arrStud.Length; i++)
                Console.WriteLine($"{i + 1})" + arrStud[i]);

            Console.Write("Поиск по имени - напишите имя школьника, номер которого вы хотите найти:");
            string name = Console.ReadLine();
            Schooler temp = new Schooler(0, 0, 0, 5, name, 133);
            int pos = Array.BinarySearch(arrStud, temp);
            if (pos >= 0) 
                Console.WriteLine($"Индекс элемента в массиве: {pos + 1}\n");
            else 
                Console.WriteLine("Школьника с таким именем нет в массиве\n");
        }

        //часть 3
        static void Menu3()
        {
            Console.WriteLine("             Меню запросов");
            Console.WriteLine("1. Массив типа IInit[], сожержащий новый класс Builder.");
            Console.WriteLine("2. Метод Sort с интерфейсом IComparable(по имени).");
            Console.WriteLine("3. Метод Sort с интерфейсом IComparer(по цене за обучение).");
            Console.WriteLine("4. Метод Sort с интерфейсом IComparer(по классу в школе).");
            Console.WriteLine("5. Поиск с помощью BinarySearch.");
            Console.WriteLine("6. Работа с интерфейсом ICloneable.");
            Console.WriteLine("7. Завершить работу программы.");
        }

        static IInit[] ArrayOfIInit()
        {
            Console.WriteLine("\nМассив содержит объекты разных классов(в том числе новый класс Builder), но их объединяет интефейс IInit, " +
                "\nпоэтому мы можем записать их все в массив типа IInit[]:");
            IInit[] arr3 = new IInit[20];
            for (int i = 0; i < 20; i++)
            {
                if (i < 5)
                {
                    Student stud = new Student();
                    stud = (Student)stud.Init();
                    arr3[i] = stud;
                }
                else if (i < 10)
                {
                    CorrespondenceStudent corStud = new CorrespondenceStudent();
                    corStud = (CorrespondenceStudent)corStud.Init();
                    arr3[i] = corStud;
                }
                else if (i < 15)
                {
                    Schooler sch = new Schooler();
                    sch = (Schooler)sch.Init();
                    arr3[i] = sch;
                }
                else if (i < 20)
                {
                    Building b = new Building();
                    b = (Building)b.Init();
                    arr3[i] = b;
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            for (int j = 0; j < arr3.Length; j++)
            {
                if (j == 5) Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                if (j == 10) Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                if (j == 15) Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{j + 1}) {arr3[j]}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            return arr3;
        }

        static Student[] DemonstrIComparable()
        {
            Student[] arrStud = new Student[7];

            for (int i = 0; i < 7; i++)
            {
                Student s = new Student();
                arrStud[i] = (Student)s.Init();
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("До сортировки:");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            foreach (var stud in arrStud)
                Console.WriteLine(stud);
            Array.Sort(arrStud);

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            Console.WriteLine("После сортировки по имени(сортировка использует реализацию стандартного интерфейса IComparable):");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrStud)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            return arrStud;
        }

        static CorrespondenceStudent[] DemonstrSortByPrice()
        {
            CorrespondenceStudent[] arrCor = new CorrespondenceStudent[7];
            for (int i = 0; i < 7; i++)
            {
                CorrespondenceStudent s = new CorrespondenceStudent();
                arrCor[i] = (CorrespondenceStudent)s.Init();
            }
            Console.WriteLine("До сортировки:");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrCor)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            Array.Sort(arrCor, new SortByPrice());

            Console.WriteLine("После сортировки по цене обучения:");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrCor)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            return arrCor;
        }

        static Schooler[] DemonstrSortByGrade()
        {
            Schooler[] arrStud = new Schooler[7];
            for (int i = 0; i < 7; i++)
            {
                Schooler s = new Schooler();
                arrStud[i] = (Schooler)s.Init();
            }
            Console.WriteLine("До сортировки:");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrStud)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            Array.Sort(arrStud, new SortByGrade());

            Console.WriteLine("После сортировки по классам в школе:");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrStud)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            return arrStud;
        }

        static Person[] DemonstrSortByHeight()
        {
            Person[] arrStud = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                Person s = new Person();
                arrStud[i] = (Person)s.Init();
            }
            Console.WriteLine("До сортировки:");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrStud)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            Array.Sort(arrStud, new SortByHeight());

            Console.WriteLine("После сортировки по росту:");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (var stud in arrStud)
                Console.WriteLine(stud);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            return arrStud;
        }

        static IInit[] CreateArrPart3()
        {
            IInit[] arr2 = new IInit[20];
            for (int i = 0; i < 20; i++)
            {
                if (i < 5)
                {
                    Student stud = new Student();
                    stud = (Student)stud.Init();
                    arr2[i] = stud;
                }
                else if (i < 10)
                {
                    CorrespondenceStudent corStud = new CorrespondenceStudent();
                    corStud = (CorrespondenceStudent)corStud.Init();
                    arr2[i] = corStud;
                }
                else if (i < 15)
                {
                    Person sch = new Person();
                    sch = (Person)sch.Init();
                    arr2[i] = sch;
                }
                else if (i < 20)
                {
                    Building b = new Building();
                    b = (Building)b.Init();
                    arr2[i] = b;
                }
            }
            return arr2;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("==========================================Лабораторная №10==============================================\n");
            Console.WriteLine("                              ЧАСТЬ №1");
            Output1();

            Person per = new Person();
            per = (Person)per.Init();

            Student student = new Student();
            student = (Student)student.Init();

            Schooler schooler = new Schooler();
            schooler = (Schooler)schooler.Init();

            CorrespondenceStudent correspStudent = new CorrespondenceStudent();
            correspStudent = (CorrespondenceStudent)correspStudent.Init();

            Output2();

            Person[] arrSimple = new Person[] { per, student, schooler, correspStudent };
            foreach (Person person in arrSimple)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                person.ShowSimple();
            }

            Output3();

            Person[] arrVirt = new Person[] { per, student, schooler, correspStudent };
            foreach (Person person in arrVirt)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                person.ShowVirt();
            }
            Output4();


            Console.WriteLine("\n\n\n                              ЧАСТЬ №2\n");

            //создание объектов для массива
            IInit[] arr2 = CreateRandomArray();

            Console.WriteLine("Элементы типа IInit в массиве:");

            //меню
            bool keepPart2 = true;
            while (keepPart2)
            {
                OutputIInitArray(arr2);
                Menu();
                int i = ParseInt("Ваш выбор: ");
                switch(i)
                {
                    case 1:
                        int count = CountSchoolesIn133School(arr2);
                        break;
                    case 2:
                        int amount = AmountScholarshipInHSE(arr2);
                        break;
                    case 3:
                        int countStud = CorrespStudOf3CourseInPSU(arr2);
                        break;
                    case 4:
                        int middleHeight = AverageHeightIn135School(arr2);
                        break;
                    case 5:
                        int maxPrice = MaxPriceOfEducatInPSU(arr2);
                        break;
                    case 6:
                        int minAge = MinStudAgeInHSE(arr2);
                        break;
                    case 7:
                        int averageWeight = AverageWeightStudInPSU(arr2);
                        break;
                    case 8:
                        keepPart2 = false;
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет в меню!");
                        break;
                }
                if (i != 8) Console.ReadKey();
            }


            Console.WriteLine("\n\n\n                              ЧАСТЬ №3\n");

            IInit[] arr3 = CreateArrPart3();

            Console.ReadKey();

            bool keepPart3 = true;
            while(keepPart3)
            {
                {
                    Menu3();
                    int i = ParseInt("Ваш выбор: ");
                    switch (i)
                    {
                        case 1:
                            ArrayOfIInit();
                            break;
                        case 2:
                            DemonstrIComparable();
                            break;
                        case 3:
                            DemonstrSortByPrice();
                            break;
                        case 4:
                            DemonstrSortByGrade();
                            break;
                        case 5:
                            BinarySearchDemonstr();
                            break;
                        case 6:
                            DemonstrCloneAndCopy();
                            break;
                        case 7:
                            keepPart3 = false;
                            break;
                        default:
                            Console.WriteLine("Такого пункта нет в меню!");
                            break;
                    }
                    if (i != 7) Console.ReadKey();
                }
            }
        }
    }
}
