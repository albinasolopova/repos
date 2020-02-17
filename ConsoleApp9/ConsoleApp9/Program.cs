using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    class Program
    {
        struct Visitor
        {
            string surname;
            string name;
            int age;
            int number;
            public Visitor(string surname, string name, int age, int number)
            {
                this. surname = surname;
                this.name=name;
                this.age = age;
                this.number = number;
            }
            public void Show(string beggining = "")
            {
                Console.WriteLine(beggining + this.surname + ","+ this.name+"," + this.age + "," + this.number);
            }
        }
        struct Section
        {
            string name;
            int price;
            public Section(string name, int price)
            {
                this.name = name;
                this.price = price;
            }
            public void Show(string beggining = "")
            {
                Console.WriteLine(beggining + this.name + "," + this.price);
            }
        }
        static List <Section> sections;
        static Dictionary<Visitor, List<Section>> Initialize()
        {
            sections = new List<Section>();
            Section dancing = new Section("танцы", 400);
            Section boxing = new Section("бокс", 400);
            Section karate = new Section("каратэ", 400);
            Section judo = new Section("дзюдо", 400);
            Section sambo = new Section("самбо", 200);
            sections.Add(dancing);
            sections.Add(boxing);
            sections.Add(karate);
            sections.Add(judo);
            sections.Add(sambo);
            Visitor visitor1 = new Visitor("Иванов"," Иван", 15, 1);
            Visitor visitor2 = new Visitor("Коваленко" ,"Анастасия", 14, 2);
            Visitor visitor3 = new Visitor("Симонов", "Петр", 17, 3);
            Visitor visitor4 = new Visitor("Норченко", "Аля", 14, 4);
            Dictionary<Visitor, List<Section>> visitors = new Dictionary<Visitor, List<Section>>();
            visitors.Add(visitor1, new List<Section>() { boxing });
            visitors.Add(visitor2, new List<Section>() { dancing });
            visitors.Add(visitor3, new List<Section>() { judo });
            visitors.Add(visitor4, new List<Section>() { sambo, dancing });
            return visitors;
        }
        static void Menu( ref Dictionary<Visitor, List<Section>> journal)
        {
            Console.WriteLine("Выбирите нужный пункт");
            Console.WriteLine("1.Вывести поситителя");
            Console.WriteLine("2.Добавить поситителя");
            Console.WriteLine("3.Удалить поситителя");
            Console.WriteLine("4.Добавить секцию");
            Console.WriteLine("5.Вывести поситителя и его секции");
            Console.WriteLine("6. Добавить посителю секцию");
            Console.WriteLine("0.Выход");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (a)
            {
                case 1:
                    ShowVisitor(journal);
                    break;
                case 2:
                    AddVisitor(ref journal);
                    break;
                case 3:
                    RemoveVisitor(ref journal);
                    break;
                case 4:
                    AddSection();
                    break;
                case 5:
                    ShowVisitorWithSection(journal);
                    break;
                case 6:
                    AddSectionToVisitor(ref journal);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Введено неправильное значение");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadLine();
                    break;
            }

            Console.ReadLine();
            Console.Clear();
            Menu(ref journal);
        }
        static void ShowVisitor(Dictionary<Visitor, List<Section>> journal)
        {
            int i = 0;
            foreach (var visitor in journal.Keys)
                visitor.Show((++i)+".");
        }
        static void AddVisitor(ref Dictionary<Visitor, List<Section>> journal)
        {
            Console.WriteLine("Введите имя и фамилию поситителя, его возраст, номер карточки");
            string surname = Console.ReadLine();
            string name = Console.ReadLine();
            int number = Convert.ToInt32(Console.ReadLine());
            int age = Convert.ToInt32(Console.ReadLine());
            journal.Add(new Visitor(surname, name, age, number), new List<Section>());
        }
        static void RemoveVisitor(ref Dictionary<Visitor, List<Section>> journal)
        {
            Console.WriteLine("Выбирите поситителя, которого хотите удалить");
            int a= Convert.ToInt32(Console.ReadLine());
            Visitor visitorToRemove = new Visitor();
            int count = 1;
            foreach(var visitor in journal.Keys)
            {
                if (count == a)
                {
                    visitorToRemove = visitor;
                    break;
                }
                count++;
            }
            journal.Remove(visitorToRemove);
        }
        static void AddSection()
        {
            Console.WriteLine("Введите название секции и ее цену");
            string name = Console.ReadLine();
            int price = Convert.ToInt32(Console.ReadLine());
            sections.Add(new Section(name, price));
        }
        static void ShowVisitorWithSection(Dictionary<Visitor, List<Section>> journal)
        {
            int count = 1;
            foreach (var pair in journal)
            {
                pair.Key.Show((++count) + ".");
                foreach(var section in pair.Value)
                {
                    section.Show(" ");
                }
            }
        }
        static void ShowSection()
        {
            int count = 1;
            foreach(var section in sections)
            {
                section.Show((count++) + ".");
            }
        }
        static void AddSectionToVisitor(ref Dictionary<Visitor, List<Section>> journal)
        {
            Console.WriteLine("Выбирите поситителя и потом секцию");
            ShowVisitor(journal);
            int a = Convert.ToInt32(Console.ReadLine());
            Visitor VisitorAddSection = new Visitor();
            int count = 1;
            foreach(var visitor in journal.Keys)
            {
                if (count == a)
                {
                    VisitorAddSection = visitor;
                    break;
                }
                count++;
            }
            ShowVisitor(journal);
            Console.Clear();
            ShowSection();
            int b = Convert.ToInt32(Console.ReadLine());
            int countb = 1;
            foreach(var section in sections)
            {
                if (b == countb)
                {
                    journal[VisitorAddSection].Add(section);
                }
                countb++;
            }

        }
        private static void Main(string[] args)
        {
            Dictionary<Visitor, List<Section>> journal = Initialize();
            Menu(ref journal);
            Console.ReadLine();
        }
    }
}
