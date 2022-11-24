using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_4.Models;
using Lab_4.Models.Unions;
using Microsoft.EntityFrameworkCore;

namespace Lab_4
{
    class Program
    {
        private static ContextTask _ct;
        static async Task Main(string[] args)
        {
            _ct = new ContextTask();
            await Task_2();
            await Task_3();
            await Task_4();
            await Task_5();
            await _ct.DisposeAsync();
            Console.WriteLine("End point app. Press enter...");
            Console.ReadLine();
        }
        
        static async Task Task_2()
        {
            Console.WriteLine("создайте таблици связей" +
                              " между этими 5ю таблицами" +
                              " Заполните эти таблицы".ToUpper());
            
            await _ct.Database.EnsureDeletedAsync();
            await _ct.Database.EnsureCreatedAsync();

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
            await _ct.SaveChangesAsync();
            
            s1.Lessons.AddRange(new List<Lesson>()
            {
                l1,
                l2
            });
            
            s2.Lessons.AddRange(new List<Lesson>()
            {
                l1,
                l2
            });
            
            s5.Lessons.AddRange(new List<Lesson>()
            {
                l1,
                l2
            });
            
            s3.Lessons.AddRange(new List<Lesson>()
            {
                l3,
                l4
            });
            s4.Lessons.AddRange(new List<Lesson>()
            {
                l3,
                l4
            });
            s6.Lessons.AddRange(new List<Lesson>()
            {
                l3,
                l4
            });
            
            s7.Lessons.Add(l5);
            s8.Lessons.Add(l5);

            for (int index = 0; index < _ct.Students.Count(); index++)
            {
                Student s = _ct.Students.ToList()[index];
                foreach (Lesson lesson in s.Lessons)
                {
                    await Task.Delay(50);
                    Total total = new()
                    {
                        Date = DateTime.Now,
                        Lesson = lesson,
                        EEm =  new Random().Next(0, 3) switch
                        {
                            0 => EvaluationMethod.E_EM.Exam,
                            1 => EvaluationMethod.E_EM.Offset,
                            2 => EvaluationMethod.E_EM.Test
                        },
                        Score = new Random().Next(51, 101)
                    };
                    s.Totals.Add(total);
                }
            }

            gs1.Students.AddRange(new List<Student>()
            {
                s1,
                s2,
                s5
            });

            gs1.Lessons.AddRange(s1.Lessons);
            
            gs2.Students.AddRange(new List<Student>()
            {
                s3,
                s4,
                s6
            });
            gs2.Lessons.AddRange(s3.Lessons);
            
            gs3.Students.AddRange(new List<Student>()
            {
                s7,
                s8
            });
            gs3.Lessons.AddRange(s7.Lessons);

            await _ct.SaveChangesAsync();
            #endregion
            
            Console.WriteLine("Готово!");
        }

        static async Task Task_3()
        {
            Console.WriteLine("Напишите запрос, который показывает " +
                              "самого (или самых, если их несколько)" +
                              "  студентов каждой группе");

            IEnumerable<Student> students = _ct.Students.ToList();
            foreach (Student student in students)
            {
                await _ct.Entry(student).Collection(c => c.GroupOfStudents).LoadAsync();
                await _ct.Entry(student).Collection(c => c.Totals).LoadAsync();
                await _ct.Entry(student).Collection(c => c.Lessons).LoadAsync();
            }

            Console.WriteLine(string.Join("\n",
                students.Where(w =>
                    w.Totals.Average(a => a.Score) <
                    students.Average(a => 
                        MathF.Round(a.Totals.Sum(s => s.Score) / a.Lessons.Count, 2)))));



            Console.WriteLine("Готово!");
        }

        static async Task Task_4()
        {
            Console.WriteLine("Создайте бекап этой базы данных");
            var ulg = new List<ULessonGroup>(await _ct.ULessonsAndGroups.ToListAsync());
            _ct.ULessonsAndGroups.RemoveRange(ulg);
            await _ct.SaveChangesAsync();
            
            var usg = new List<UStudentGroup>(await _ct.UStudentsAndGroups.ToListAsync());
            _ct.UStudentsAndGroups.RemoveRange(usg);
            await _ct.SaveChangesAsync();
            
            var usl = new List<UStudentLesson>(await _ct.UStudentLessons.ToListAsync());
            _ct.UStudentLessons.RemoveRange(usl);
            await _ct.SaveChangesAsync();
            
            var totals = new List<Total>(await _ct.Totals.ToListAsync());
            _ct.Totals.RemoveRange(totals);
            await _ct.SaveChangesAsync();

            var students = new List<Student>(await _ct.Students.ToListAsync());
            _ct.Students.RemoveRange(students);
            await _ct.SaveChangesAsync();

            var lessons = new List<Lesson>(await _ct.Lessons.ToListAsync());
            _ct.Lessons.RemoveRange(lessons);
            await _ct.SaveChangesAsync();

            var groups = new List<GroupOfStudent>(await _ct.GroupOfStudents.ToListAsync());
            _ct.GroupOfStudents.RemoveRange(groups);
            await _ct.SaveChangesAsync();
            
            await new BackupModel(
                    totals,
                    students,
                    lessons,
                    groups,
                    ulg,
                    usg,
                    usl)
                .Write();
            
            Console.WriteLine("Готово!");
        }
        
        static async Task Task_5()
        {
            Console.WriteLine("Удалите все таблици и восстановите их-из бекапа");
            await _ct.Database.EnsureDeletedAsync();
            await _ct.Database.EnsureCreatedAsync();

            BackupModel bm = await BackupModel.Read();
            
            _ct.GroupOfStudents.AddRange(bm.GroupOfStudents);
            

            _ct.Lessons.AddRange(bm.Lessons);

            _ct.Students.AddRange(bm.Students);
            await _ct.SaveChangesAsync();
            
            _ct.Totals.AddRange(bm.Totals);
            
            await _ct.SaveChangesAsync();
           
            
            Console.WriteLine("Готово!");
        }
    }
}