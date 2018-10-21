using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFinalProject
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public string SecondName { get ; set; }
        public DateTime BirthDay { get ; set ; }
        public DateTime EmploymentDate { get ; set ; }
        public string Position { get ; set ; }
        public string Division { get ; set ; }
        public int Room { get ; set ; }
        public int Phone { get ; set ; }
        public string Email { get ; set ; }
        public int Salary { get ; set ; }
        public string Notes { get ; set ; }

        public Employee()
        {
        }
        public Employee(int id, string surname, string name, string secondname, DateTime birthday, DateTime empDate, string pos, string div, int room, int phone, string email, int salary, string note)
        {
            ID = id;
            Name = name;
            Surname = surname;
            SecondName = secondname;
            BirthDay = birthday;
            EmploymentDate = empDate;
            Position = pos;
            Division = div;
            Room = room;
            Phone = phone;
            Email = email;
            Salary = salary;
            Notes = note;
        }
        public override string ToString()
        {
            return String.Format(ID + "; " + Surname + "; " + Name + "; " + SecondName + "; " + BirthDay.ToShortDateString() + "; " + EmploymentDate.ToShortDateString() + "; " + Position + "; " + Division + "; " + Room + "; " + Phone + "; " + Email + "; " + Salary + "; " + Notes);
        }
        public static explicit operator Employee(string str)
        {
            string[] separator = new string[] { "; " };
            string[] sm = str.Split(separator, StringSplitOptions.None);
            return new Employee(int.Parse(sm[0]),sm[1],sm[2],sm[3],DateTime.Parse(sm[4]),DateTime.Parse(sm[5]),sm[6],sm[7],int.Parse(sm[8]),int.Parse(sm[9]),sm[10],int.Parse(sm[11]),sm[12]);
        }
    }
    public class Employees : IEnumerable
    {
        List<Employee> employees = new List<Employee>();
        public void AddEmployee(string name, string surname, string secondname, DateTime birthday, DateTime empDate, string pos, string div, int room, int phone, string email, int salary, string note)
        {
            employees.Add(new Employee(employees[employees.Count-1].ID+1, name, surname, secondname, birthday, empDate, pos, div, room, phone, email, salary, note));
        }
        public void AddEmployee(Employee e)
        {
            employees.Add(e);
        }
        public void AddEmployee()
        {
            Employee e = new Employee();
            e.ID = employees[employees.Count - 1].ID + 1;
            Console.WriteLine("Прізвище:");
            e.SecondName= Console.ReadLine();
            Console.WriteLine("Ім'я:");
            e.Name  = Console.ReadLine();
            Console.WriteLine("По-батькові:");
            e.Surname = Console.ReadLine();
            Console.WriteLine("Дата народження:");
            e.BirthDay =  DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Дата прийняття на роботу:");
            e.EmploymentDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Посада:");
            e.Position = Console.ReadLine();
            Console.WriteLine("Підрозділ");
            e.Division = Console.ReadLine();
            Console.WriteLine("Номер кімнати:");
            e.Room = int.Parse(Console.ReadLine());
            Console.WriteLine("Службовий телефон:");
            e.Phone = int.Parse(Console.ReadLine());
            Console.WriteLine("Зарплата:");
            e.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine("e-mail:");
            e.Email = Console.ReadLine();
            Console.WriteLine("Нотатки:");
            e.Notes = Console.ReadLine();
            employees.Add(e);
        }
        public void DeleteEmployee(int id)
        {
            try
            {
                employees.RemoveAt(IdToIndex(id));
                Console.WriteLine("Видалення завершено успішно");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Працівника з таким ID не існує!");
            }
        }
        public void EditEmployee(int id)
        {
            try
            {
                int i = IdToIndex(id);
                Console.WriteLine("Enter new value for position:");
                employees[i].Position = Console.ReadLine();
                Console.WriteLine("Enter new value for division:");
                employees[i].Division = Console.ReadLine();
                Console.WriteLine("Enter new value for room number:");
                employees[i].Room = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new value for phone:");
                employees[i].Phone = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new value for salary:");
                employees[i].Salary = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new value for e-mail:");
                employees[i].Email = Console.ReadLine();
                Console.WriteLine("Enter new value for notes:");
                employees[i].Notes = Console.ReadLine();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Працівника з таким ID не існує!");
                //throw;
            }
        }
        int IdToIndex(int id)
        {
            foreach (Employee e in employees)
            {
                if (e.ID == id)
                {
                    return employees.IndexOf(e);
                }
            }
            return -1;
        }
        public IEnumerator GetEnumerator()
        {
            return employees.GetEnumerator();
        }
    }
}
