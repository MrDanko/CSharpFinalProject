using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("data.txt");

            FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

            Employees employee = new Employees();
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    employee.AddEmployee((Employee)line);
                }
            }
            Action(employee);
            foreach (Employee e in employee)
            {
                Console.WriteLine(e);
            }
            stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (Employee emp in employee)
                {
                    writer.WriteLine(emp);
                }
            }
            
            Console.ReadKey();
        }
        public static void Read()
        {
            
        }
        public static void Action(Employees e)
        {
            string choice;
            Console.WriteLine("Виберіть дію яку ви хочете виконати:");
            Console.WriteLine("1: додати нового працівника");
            Console.WriteLine("2: переглянути дані працівника");
            Console.WriteLine("3: редагувати існуючого працівника");
            Console.WriteLine("4: видалити існуючого працівника");
            Console.WriteLine("5: згенерувати звіт");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Show();
                    break;
                case "3":
                    Edit();
                    break;
                case "4":
                    Delete();
                    break;
                case "5":
                    Summary();
                    break;
                default:
                    Console.Clear();
                    Action(e);
                    break;
            }
            void Summary()
            {
                throw new NotImplementedException();
            }
            void Delete()
            {
                Console.WriteLine("Введіть Id працівника, якого потрібно видалити:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ви дійсно хочете видалити цього працівника?");
                Console.WriteLine("1: так");
                Console.WriteLine("2: ні");
                switch (Console.ReadLine())
                {
                    case "1":
                        e.DeleteEmployee(id);
                        Action(e);
                        break;
                    case "2":
                        Console.WriteLine("Видалення відмінено!");
                        Action(e);
                        break;
                }
                
                

            }
            void Edit()
            {
                Console.WriteLine("Введіть Id працівника, якого потрібно редагувати:");
                int id = Convert.ToInt32(Console.ReadLine());
                e.EditEmployee(id);
            }

            void Add()
            {
                e.AddEmployee();
            }

            void Show()
            {
                foreach (Employee emp in e)
                {
                    Console.WriteLine(emp);
                }
            }
        }




    }
}