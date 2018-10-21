using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFinalProject
{
    class TableBilder
    {
        public static void Table(Employees e)
        {
            int rowMaxLength = Console.LargestWindowWidth;
            //int columnCount = 13;
            //int cellDefaultLength = (rowMaxLength - 23) / (columnCount - 3);
            int maxName = 6, maxSurname = 10, maxSecName = 13,
                maxPos = 8, maxDiv = 11, maxPhone = 11, 
                maxRoom = 9, maxSalary = 10, maxMail = 11;
            foreach (Employee emp in e)
            {
                maxName = (maxName <= emp.Name.Length+2) ? emp.Name.Length+2 : maxName;
                maxSurname = (maxSurname <= emp.Surname.Length+2) ? emp.Surname.Length +2: maxSurname;
                maxSecName = (maxSecName <= emp.SecondName.Length+2) ? emp.SecondName.Length +2: maxSecName;
                maxPos = (maxPos <= emp.Position.Length+2) ? emp.Position.Length +2: maxPos;
                maxDiv = (maxDiv <= emp.Division.Length+2) ? emp.Division.Length+2 : maxDiv;
                maxPhone = (maxPhone <= emp.Phone.ToString().Length+2) ? emp.Phone.ToString().Length +2: maxPhone;
                maxRoom = (maxRoom <= emp.Room.ToString().Length+2) ? emp.Room.ToString().Length+2 : maxRoom;
                maxSalary = (maxSalary <= emp.Salary.ToString().Length+2) ? emp.Salary.ToString().Length +2: maxSalary;
                maxMail = (maxMail <= emp.Email.Length+2) ? emp.Email.Length +2: maxMail;
            }
            int maxNotes = rowMaxLength - 33 - maxName - maxDiv - maxMail - maxPhone
                - maxPos - maxRoom - maxSalary - maxSecName - maxSurname;
            //header
            Console.WriteLine("\u2554".PadRight(5, '\u2550') + "\u2566".PadRight(maxSurname, '\u2550') + "\u2566".PadRight(maxName, '\u2550') + "\u2566".PadRight(maxSecName, '\u2550') + "\u2566".PadRight(12, '\u2550') + "\u2566".PadRight(maxPos, '\u2550') + "\u2566".PadRight(maxDiv, '\u2550') + "\u2566".PadRight(maxRoom, '\u2550') + "\u2566".PadRight(maxPhone, '\u2550') + "\u2566".PadRight(maxMail, '\u2550') + "\u2566".PadRight(maxSalary, '\u2550') + "\u2566".PadRight(12, '\u2550') + "\u2566".PadRight(maxNotes, '\u2550') + '\u2557');
            Console.WriteLine("\u2551 ID ".PadRight(5) + "\u2551 Прізвище".PadRight(maxSurname) + "\u2551 Ім'я".PadRight(maxName) + "\u2551 По-батькові".PadRight(maxSecName) + "\u2551 Дата ".PadRight(12) + "\u2551 Посада".PadRight(maxPos) + "\u2551 Підрозділ".PadRight(maxDiv) + "\u2551 Номер".PadRight(maxRoom) + "\u2551 Службовий".PadRight(maxPhone) + "\u2551 Службовий".PadRight(maxMail) + "\u2551 Місячний".PadRight(maxSalary) + "\u2551 Дата".PadRight(12) + "\u2551 Поле".PadRight(maxNotes) + "\u2551");
            Console.WriteLine("\u2551".PadRight(5) + "\u2551 ".PadRight(maxSurname) + "\u2551 ".PadRight(maxName) + "\u2551 ".PadRight(maxSecName) + "\u2551 народження".PadRight(12) + "\u2551 ".PadRight(maxPos) + "\u2551 ".PadRight(maxDiv) + "\u2551 кімнати".PadRight(maxRoom) + "\u2551 телефон".PadRight(maxPhone) + "\u2551 e-mail".PadRight(maxMail) + "\u2551 оклад".PadRight(maxSalary) + "\u2551 прийняття".PadRight(12) + "\u2551 для".PadRight(maxNotes) + "\u2551");
            Console.WriteLine("\u2551".PadRight(5) + "\u2551 ".PadRight(maxSurname) + "\u2551 ".PadRight(maxName) + "\u2551 ".PadRight(maxSecName) + "\u2551".PadRight(12) + "\u2551 ".PadRight(maxPos) + "\u2551 ".PadRight(maxDiv) + "\u2551".PadRight(maxRoom) + "\u2551".PadRight(maxPhone) + "\u2551".PadRight(maxMail) + "\u2551".PadRight(maxSalary) + "\u2551 на роботу".PadRight(12) + "\u2551 приміток".PadRight(maxNotes) + "\u2551");
            // body
            foreach (Employee emp in e)
            {
                Console.WriteLine("\u2560".PadRight(5, '\u2550') + "\u256C".PadRight(maxSurname, '\u2550') + "\u256C".PadRight(maxName, '\u2550') + "\u256C".PadRight(maxSecName, '\u2550') + "\u256C".PadRight(12, '\u2550') + "\u256C".PadRight(maxPos, '\u2550') + "\u256C".PadRight(maxDiv, '\u2550') + "\u256C".PadRight(maxRoom, '\u2550') + "\u256C".PadRight(maxPhone, '\u2550') + "\u256C".PadRight(maxMail, '\u2550') + "\u256C".PadRight(maxSalary, '\u2550') + "\u256C".PadRight(12, '\u2550') + "\u256C".PadRight(maxNotes, '\u2550') + '\u2563');
                Console.WriteLine($"\u2551 {emp.ID}".PadRight(5) + $"\u2551 {emp.Surname}".PadRight(maxSurname) + $"\u2551 {emp.Name}".PadRight(maxName) + $"\u2551 {emp.SecondName}".PadRight(maxSecName) + $"\u2551 {emp.BirthDay.ToShortDateString()}".PadRight(12) + $"\u2551 {emp.Position}".PadRight(maxPos) + $"\u2551 {emp.Division}".PadRight(maxDiv) + $"\u2551 {emp.Room}".PadRight(maxRoom) + $"\u2551 {emp.Phone}".PadRight(maxPhone) + $"\u2551 {emp.Email}".PadRight(maxMail) + $"\u2551 {emp.Salary}".PadRight(maxSalary) + $"\u2551 {emp.EmploymentDate.ToShortDateString()}".PadRight(12) + $"\u2551 {emp.Notes}".PadRight(maxNotes) + "\u2551");
            }
            //end of table
            Console.WriteLine("\u255A".PadRight(5, '\u2550') + "\u2569".PadRight(maxSurname, '\u2550') + "\u2569".PadRight(maxName, '\u2550') + "\u2569".PadRight(maxSecName, '\u2550') + "\u2569".PadRight(12, '\u2550') + "\u2569".PadRight(maxPos, '\u2550') + "\u2569".PadRight(maxDiv, '\u2550') + "\u2569".PadRight(maxRoom, '\u2550') + "\u2569".PadRight(maxPhone, '\u2550') + "\u2569".PadRight(maxMail, '\u2550') + "\u2569".PadRight(maxSalary, '\u2550') + "\u2569".PadRight(12, '\u2550') + "\u2569".PadRight(maxNotes, '\u2550') + '\u255D');

        }
    }
    
}

