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
                    Summary(e);
                    break;
                default:
                    Console.Clear();
                    Action(e);
                    break;
            }
            void Summary(Employees empl)
            {
                string field,criteria;
                Console.WriteLine("Виберіть поле для вибірки:");
                Console.WriteLine("1: ПІБ");
                Console.WriteLine("2: Дата народження");
                Console.WriteLine("3: Посада");
                Console.WriteLine("4: Підрозділ");
                Console.WriteLine("5: Оклад");
                Console.WriteLine("6: Дата працевлаштування");
                field = Console.ReadLine();
                IEnumerable<Employee> result;
                switch (field)
                {
                    case "1":
                        criteria = Criteria();
                        result = from Employee emp in empl
                                           where emp.Name.ToUpper().Contains(criteria.ToUpper())|| emp.SecondName.Contains(criteria.ToUpper()) || emp.Surname.Contains(criteria.ToUpper())
                                           select emp;
                        foreach (Employee emp in result)
                        {
                            Console.WriteLine(emp);
                        }
                        break;
                    case "2":
                        criteria = Criteria();
                       result = from Employee emp in empl
                                                       where emp.BirthDay==DateTime.Parse(criteria)
                                                       select emp;
                        foreach (Employee emp in result)
                        {
                            Console.WriteLine(emp);
                        }
                        break;
                    case "3":
                        criteria = Criteria();
                        result = from Employee emp in empl
                                                       where emp.position==criteria
                                                       select emp;
                        foreach (Employee emp in result)
                        {
                            Console.WriteLine(emp);
                        }
                        break;
                    case "4":
                        criteria = Criteria();
                        result = from Employee emp in empl
                                                       where emp.division==criteria
                                                       select emp;
                        foreach (Employee emp in result)
                        {
                            Console.WriteLine(emp);
                        }
                        break;
                    case "5":
                        criteria = Criteria();
                        result = from Employee emp in empl
                                                       where emp.salary==int.Parse(criteria)
                                                       select emp;
                        foreach (Employee emp in result)
                        {
                            Console.WriteLine(emp);
                        }
                        break;
                    case "6":
                        criteria = Criteria();
                        result = from Employee emp in empl
                                                       where emp.employmentDate== DateTime.Parse(criteria)
                                 select emp;
                        foreach (Employee emp in result)
                        {
                            Console.WriteLine(emp);
                        }
                        break;
                    default:
                        Console.Clear();
                        Summary(e);
                        break;
                }
                


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
                FileInfo file = new FileInfo("data.txt");

                FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

                stream = file.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (Employee emp in e)
                    {
                        writer.WriteLine(emp);
                    }
                }


            }
            void Edit()
            {
                Console.WriteLine("Введіть Id працівника, якого потрібно редагувати:");
                int id = Convert.ToInt32(Console.ReadLine());
                e.EditEmployee(id);
                FileInfo file = new FileInfo("data.txt");

                FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

                stream = file.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (Employee emp in e)
                    {
                        writer.WriteLine(emp);
                    }
                }
            }
            void Add()
            {
                e.AddEmployee();
                FileInfo file = new FileInfo("data.txt");

                FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

                stream = file.Open(FileMode.Append, FileAccess.ReadWrite, FileShare.Read);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (Employee emp in e)
                    {
                        writer.WriteLine(emp);
                    }
                }
            }
            void Show()
            {
                foreach (Employee emp in e)
                {
                    Console.WriteLine(emp);
                }
            }
            string Criteria()
            {
                Console.WriteLine("Введіть критерій пошуку:");
                return Console.ReadLine();
            }
        }




    }
}