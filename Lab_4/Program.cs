using System;
using System.Collections.Generic;
using Lab_4.Models;

namespace Lab_4
{
    class Program
    {
        private static ContextTask _ct;
        static void Main(string[] args)
        {
            _ct = new ContextTask();
            
            _ct.Dispose();
        }

        static void Task_2()
        {
            Console.WriteLine("создайте таблици связей" +
                              " между этими 5ю таблицами" +
                              " Заполните эти таблицы".ToUpper());
            
            _ct.Database.EnsureDeleted();
            _ct.Database.EnsureCreated();

            #region grps

            GroupOfStudent gs1 = new GroupOfStudent()
            {
                Name = "G_1"
            };
            
            GroupOfStudent gs2 = new GroupOfStudent()
            {
                Name = "G_2"
            };
            
            GroupOfStudent gs3 = new GroupOfStudent()
            {
                Name = "G_3"
            };

            #endregion

            #region lessons

            Lesson l1 = new Lesson()
            {
                Name = "УМФ",
                Hour = 32
            };
            
            Lesson l2 = new Lesson()
            {
                Name = "ДУ",
                Hour = 45
            };
            
            Lesson l3 = new Lesson()
            {
                Name = "Мат.Анализ",
                Hour = 40
            };
            
            Lesson l4 = new Lesson()
            {
                Name = "Функ.Анализ",
                Hour = 38
            };
            
            Lesson l5 = new Lesson()
            {
                Name = "Тер.Вер.",
                Hour = 41
            };

            #endregion

            #region srudents
            
            Student s1 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Иван",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s2 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Алексей",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s3 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Екатерина",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s4 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Егор",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s5 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Анна",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s6 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Елена",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s7 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Лада",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            
            Student s8 = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Константин",
                NumOfStudent = Guid.NewGuid().ToString()
            };
            #endregion

            #region action

            _ct.Students.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);
            _ct.Lessons.AddRange(l1, l2, l3, l4, l5);
            _ct.GroupOfStudents.AddRange(gs1, gs2, gs3);
            _ct.SaveChanges();

            gs1.Students.AddRange(new List<Student>()
            {
                s1,
                s2,
                s5
            });
            
            gs2.Students.AddRange(new List<Student>()
            {
                s3,
                s4,
                s6
            });
            
            gs3.Students.AddRange(new List<Student>()
            {
                s7,
                s8
            });

            #endregion
            
            Console.WriteLine("Готово!");
        }
    }
}