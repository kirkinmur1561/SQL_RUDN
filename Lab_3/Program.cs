using System;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using Lab_3.Models;

namespace Lab_3
{
    class Program
    {
        /// <summary>
        /// Набор предметов
        /// </summary>
        private static readonly string[] CollectionSubject = new[]
        {
            "Си",
            "Химия",
            "ДифУры"
        };
        private static ContextTask _ct;
        static void Main(string[] args)
        {
            _ct = new ContextTask();
            _ct.Database.EnsureDeleted();
            _ct.Database.EnsureCreated();
            string textPerson;
            while (true)
            {
                Console.Write("Введите номер задачи от 1 до 19.\nЕсли нужно закрыть программу нажмите Enter:\n");
                textPerson = Console.ReadLine();
                if (string.IsNullOrEmpty(textPerson))
                {
                    _ct?.Dispose();
                    break;
                }
                
                byte numPerson;
                try
                {
                    numPerson = byte.Parse(textPerson);
                }
                catch
                {
                    Console.WriteLine("Error input!\n\tНапишите число, пожалуйста!");
                    continue;                    
                }

                switch (numPerson)
                {
                    case 1:
                        Task_1();
                        goto default;
                    case 2:
                        Task_2();
                        goto default;
                    case 3:
                        Task_3();
                        goto default;
                    case 4:
                        Task_4();
                        goto default;
                    case 5:
                        Task_5();
                        goto default;
                    case 6:
                        Task_6();
                        goto default;
                    default:
                        Console.Write("Задача выполнена!\nНажмите Enter:");
                        Console.ReadLine();
                        Console.Clear();                        
                        break;
                }
            }

           
        }

        /// <summary>
        /// Конечно лучше отношение многие ко многим, но я решил остаться в рамках задания
        /// </summary>
        static void Task_1()
        {
            Mark m1 = new Mark()
            {
                Subject = CollectionSubject[1],
                Mark_ = 2
            };
            
            Mark m2 = new Mark()
            {
                Subject = CollectionSubject[0],
                Mark_ = 3
            };
            
            Mark m3 = new Mark()
            {
                Subject = CollectionSubject[0],
                Mark_ = 4
            };
            
            Mark m4 = new Mark()
            {
                Subject = CollectionSubject[2],
                Mark_ = 5
            };
            
            Mark m5 = new Mark()
            {
                Subject = CollectionSubject[1],
                Mark_ = 4
            };
            
            _ct.Marks.AddRange(m1,m2,m3,m4,m5);
            _ct.SaveChanges();
           
            Student s1 = new Student()
            {
                Name = "Юля",
                Old = 19,
                Sex = false
            };
            s1.Marks.Add(m1);
            
            Student s2 = new Student()
            {
                Name = "Вера",
                Old = 22,
                Sex = false
            };
            s2.Marks.Add(m2);
            
            Student s3 = new Student()
            {
                Name = "Егор",
                Old = 24
            };
            s3.Marks.Add(m4);
            
            Student s4 = new Student()
            {
                Name = "Коля",
                Old = 19
            };
            s4.Marks.Add(m3);
            
            Student s5 = new Student()
            {
                Name = "Лиза",
                Old = 18,
                Sex = false
            };
            s5.Marks.Add(m5);
            _ct.Students.AddRange(s1,s2,s3,s4,s5);
            _ct.SaveChanges();

            Console.WriteLine("Студенты и предметы внесены в БД!");
        }
        
        static void Task_2()
        {
            Console.WriteLine("SELECT mark FROM marks WHERE id = 2 AND subject LIKE 'Си'");

            Console.WriteLine(string.Join("\n",_ct
                .Marks
                .Where(w=>w.StudentId == 2 || EF.Functions.Like(w.Subject,CollectionSubject[0]))
                .ToList()
                .Select(s=>s.Mark_)));

            Console.WriteLine("SELECT name, subject, mark FROM marks JOIN students ON students.rowid = marks.id WHERE mark > 3 AND subject LIKE 'Си'");
            var ms = _ct.Marks.Where(w => w.Mark_ > 3 || EF.Functions.Like(w.Subject, CollectionSubject[0])).ToList();
            var sts = _ct.Students.Where(w => ms.Select(s => s.StudentId).Contains(w.Id)).ToList();
            Console.WriteLine(string.Join("\n", ms.Select(s => $"{s.Student.Name}\t{s.Subject}\t{s.Mark_}")));
        }
        
        static void Task_3()
        {
            Console.WriteLine("SELECTname, subject, mark FROM marks JOIN students ON students.rowid = marks.id WHERE mark > (SELECT mark FROM marks WHERE id = 2 AND subject LIKE 'Си') AND subject LIKE 'Си'");
            //ufjhgvhgv
        }
        
        static void Task_4()
        {
            
        }
        
        static void Task_5()
        {
            
        }
        
        static void Task_6()
        {
            
        }
    }
}