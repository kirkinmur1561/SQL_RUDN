using System;
using System.Linq;
using System.Text.RegularExpressions;
using Lab_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab_2
{
    class Program
    {
        static ContextTask _ct;
        static void Main(string[] args)
        {
            _ct = new ContextTask();
            string textPerson;
            while (true)
            {
                Console.Write("Введите номер задачи от 1 до 19.\nЕсли нужно закрыть программу нажмите Enter:\n");
                textPerson = Regex.Replace(Console.ReadLine(), "\\.|,", "");
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

                if (numPerson is (< 1 or > 19) and (< 51 or > 53))
                {
                    Console.WriteLine("Нет такого задания!!!\nНажмите на Enter чтобы ввести число еще раз!");
                    Console.ReadLine();
                    Console.Clear(); 
                    continue;
                }

                Console.WriteLine("TASK #" + numPerson);
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
                    case 6:
                        Task_6();
                        goto default;
                    case 7:
                        Task_7();
                        goto default;
                    case 8:
                        Task_8();
                        goto default;
                    case 9:
                        Task_9();
                        goto default;
                    case 10:
                        Task_10();
                        goto default;
                    case 11:
                        Task_11();
                        goto default;
                    case 12:
                        Task_12();
                        goto default;
                    case 13:
                        Task_13();
                        goto default;
                    case 14:
                        Task_14();
                        goto default;
                    case 15:
                        Task_15();
                        goto default;
                    case 16:
                        Task_16();
                        goto default;
                    case 17:
                        Task_17();
                        goto default;
                    case 18:
                        Task_18();
                        goto default;
                    case 19:
                        Task_19();
                        goto default;    
                    case 51:
                        Task_5_1();
                        goto default;
                    case 52:
                        Task_5_2();
                        goto default;
                    case 53:
                        Task_5_3();
                        goto default;
                    default:
                        Console.Write("Задача выполнена!\nНажмите Enter:");
                        Console.ReadLine();
                        Console.Clear();                        
                        break;                    
                }
            }            
        }
        
        static void Task_1()
        {           
            _ct.Database.EnsureDeleted();
            Console.WriteLine("Таблица оцищена");
            _ct.Database.EnsureCreated();
            Console.WriteLine("Таблица создана");
            User u1 = new User()
            {
                Name = "Алексей",
                Old = 22,
                Score = 1000
            };
            User u2 = new User(){
                Name = "Миша",
                Old = 19,
                Score = 800
            };
            User u3 = new User(){
                Name = "Федер",
                Old = 26,
                Score = 1100
            };
            User u4 = new User(){
                Name = "Маша",
                Old = 18,
                Score = 1500,
                Sex = false
            };
            
            _ct.Users.AddRange(u1,u2,u3,u4);
            _ct.SaveChanges();
            Console.WriteLine("В таблицу добавлены данные.");

            var collect_users = _ct.Users.ToList();
            
            Console.WriteLine("SELECT * FROM Users");            
            collect_users.ForEach(f => Console.WriteLine(f.ToString()));

            Console.WriteLine("SELECT rowid, * FROM Users");
            collect_users.ForEach(f => Console.WriteLine($"{collect_users.IndexOf(f) + 1} {f.ToString()}"));

            Console.WriteLine("DROP TABLE Users");
            _ct.Database.EnsureDeleted();

        }
        
        static void Task_2()
        {
            _ct.Database.EnsureDeleted();
            _ct.Database.EnsureCreated();

            User u1 = new User()
            {
                Name = "Алексей",
                Old = 18,
                Score = 1000
            };

            _ct.Users.Add(u1);
            _ct.SaveChanges();
            Console.WriteLine("В таблицу был добавлена запись!\n" +
                              "INSERT INTO Users (Name, Old, Score) VALUES('Алексей', 18, 1000)");            
        }

        static void Task_3() =>
            Console.WriteLine("INSERT INTO users (name, old, score) VALUES('Алексей', 18, 1000)\n" +
                              "При новой записи в таблицу Users поле Sex - значение по умолчанию - true (Муж. пол)");        
        static void Task_4()
        {
            User u1 = new User()
            {
                Name = "Михаил",
                Old = 19,
                Score = 1000,
                Sex = true
                    
            };
            
            User u2 = new User()
            {
                Name = "Федер",
                Old = 32,
                Score = 200
            };

            _ct.Users.AddRange(u1, u2);
            _ct.SaveChanges();

            Console.WriteLine("В таблицу Users были добавлены данные\n" +
                              "\tINSERT INTO users VALUES('Михаил', 1, 19, 1000)\n" +
                              "\tINSERT INTO users (name, old, score) VALUES('Федор', 32, 200)");
        }
        
        static void Task_5_1()
        {
            Console.WriteLine("SELECT name, old, score FROM users");
            _ct
                .Users
                .Select(s => new
            {
                Name = s.Name,
                Old = s.Old,
                Score = s.Score
            }).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}\t{f.Old}\t{f.Score}"));

            Console.WriteLine("SELECT * FROM users");
            _ct
                .Users
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
        }
        
        static void Task_5_2()
        {
            var common_collect = _ct.Users.ToList();
            Console.WriteLine("SELECT * FROM users WHERE score < 1000");
            common_collect
                .Where(w => w.Score < 1000)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE score BETWEEN 500 AND 1000");
            common_collect
            .Where(w => w.Score <= 500 && w.Score >= 1000)
            .ToList()
            .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE old = 32");
            common_collect
                .Where(w => w.Old == 32)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
        }
        
        static void Task_5_3()
        {
            var common_collect = _ct.Users.ToList();
            
            Console.WriteLine("SELECT * FROM users WHERE old > 20 AND score < 1000");
            common_collect
                .Where(w => w.Old > 20 && w.Score < 1000)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE old IN(19, 32) AND score < 1000");
            common_collect
                .Where(w => w.Old is 19 or 32 && w.Score < 1000)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE old IN(19, 32) AND score > 300 OR sex = 1");
            common_collect
                .Where(w => (w.Old is 19 or 32 || w.Score > 300) && !w.Sex)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));

            Console.WriteLine("SELECT * FROM users WHERE (old IN(19, 32) OR sex = 1) AND score > 300");
            common_collect
                .Where(w => (w.Old is 19 or 32 || !w.Sex) && w.Score > 300)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
                
            Console.WriteLine("SELECT * FROM users WHERE old IN(19, 32) AND NOT score > 300");
            common_collect
                .Where(w => w.Old is 19 or 32 && !(w.Score > 300))
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
        }
        
        static void Task_6()
        {
            var common_collect = _ct.Users.ToList();
            Console.WriteLine("SELECT * FROM users WHERE score < 1000 ORDER BY old");
            common_collect
                .Where(w => w.Score < 1000)
                .OrderBy(ob => ob.Old)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE score < 1000 ORDER BY old DESC");
            common_collect
                .Where(w => w.Score < 1000)
                .OrderByDescending(user => user.Old)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE score < 1000 ORDER BY old ASC");
            common_collect
                .Where(w => w.Score < 1000)
                .OrderBy(ob => ob.Old)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
        }
        
        static void Task_7()
        {
            User u1 = new User()
            {
                Name = "Мария",
                Old = 18,
                Score = 400,
                Sex = false
            };
            
            User u2 = new User()
            {
                Name = "Сергей",
                Old = 33,
                Score = 2000
            };
            
            User u3 = new User()
            {
                Name = "Владимир",
                Old = 43,
                Score = 100
            };
            
            User u4 = new User()
            {
                Name = "Елена",
                Old = 17,
                Score = 500,
                Sex = false
            };
            
            User u5 = new User()
            {
                Name = "Юля",
                Old = 23,
                Score = 700,
                Sex = false
            };

            _ct.Users.AddRange(u1, u2, u3, u4, u5);
            _ct.SaveChanges();

            Console.WriteLine("TOP 5 list person:");
            _ct
                .Users
                .Where(w => w.Score > 100)
                .OrderByDescending(ob => ob.Score)
                .Take(5)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
        }
        
        static void Task_8()
        {
            var common_collect = _ct.Users.ToList();
            
            Console.WriteLine("SELECT * FROM users WHERE score > 100 ORDER BY score DESC LIMIT 5 OFFSET 2");
            common_collect
                .Where(w => w.Score > 100)
                .OrderByDescending(ob => ob.Score)
                .Skip(2)
                .Take(5)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
            Console.WriteLine("SELECT * FROM users WHERE score > 100 ORDER BY score DESC LIMIT 2, 5");
            common_collect
                .Where(w => w.Score > 100)
                .OrderByDescending(ob => ob.Score)
                .Skip(2)
                .Take(5)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));

            Console.WriteLine("SELECT * FROM users WHERE score > 100 ORDER BY score DESC LIMIT 5 (Take TOP 5 person)");
            common_collect
                .Where(w => w.Score > 100)
                .OrderByDescending(ob => ob.Score)                
                .Take(5)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));
            
        }
        
        static void Task_9()
        {
            var common_collect = _ct.Users.ToList();
            
            Console.WriteLine("UPDATE users SET score = 1000 WHERE rowid = 1");
            User u1 = _ct.Users.FirstOrDefault();
            u1.Score = 1000;
            _ct.Users.Update(u1);
            _ct.SaveChanges();            
            
            Console.WriteLine("Таблица обновлена.\nUPDATE users SET score = score+500 WHERE sex = 2");
            var u_s = _ct.Users.Where(w => w.Sex).ToList();
            u_s.ForEach(f => f.Score += 500);
            _ct.Users.UpdateRange(u_s);
            _ct.SaveChanges();            
            
            Console.WriteLine("Таблица обновлена.\nUPDATE users SET score = 1500 WHERE name LIKE 'Федор'");
            u_s = _ct
                .Users
                .Where(w => EF.Functions.Like(w.Name,"Федер"))
                .ToList();
            u_s.ForEach(f => f.Score = 1500);
            _ct.Users.UpdateRange(u_s);
            _ct.SaveChanges();
                
            
            Console.WriteLine("Таблица обновлена.\nUPDATE users SET score = score+100 WHERE name LIKE 'М%'");
            u_s = _ct
                .Users
                .Where(w => EF.Functions.Like(w.Name, "М%"))
                .ToList();
            u_s.ForEach(f => f.Score += 100);
            _ct.Users.UpdateRange(u_s);
            _ct.SaveChanges();
            
            
            Console.WriteLine("Таблица обновлена.\nUPDATE users SET score = score+100 WHERE name LIKE 'С_рг%'");
            u_s = common_collect
                .Where(w => EF.Functions.Like(w.Name, "С_рг%"))
                .ToList();
            u_s.ForEach(f => f.Score += 100);
            _ct.Users.UpdateRange(u_s);
            _ct.SaveChanges();
            
            Console.WriteLine("Таблица обновлена.\nUPDATE users SET score = 700, old = 45 WHERE old > 40");
            u_s = common_collect
                .Where(w => w.Old > 40)
                .ToList();
            u_s.ForEach(f =>
            {
                f.Score = 700;
                f.Old = 45;
            });
            _ct.Users.UpdateRange(u_s);
            _ct.SaveChanges();

            Console.WriteLine("Таблица обновлена.");
        }   
        
        static void Task_10()
        {
            Console.WriteLine("DELETE FROM users WHERE rowid IN(2, 5)");
            var u_t = _ct.Users.ToList();
            User u1 = null;
            User u2 = null;
            try
            {
                u1 = u_t[1];
                u2 = u_t[4];
            }
            catch
            {}

            if (u1 != null) _ct.Users.Remove(u1);
            if (u2 != null) _ct.Users.Remove(u2);
            _ct.SaveChanges();            
            
            Console.WriteLine("SELECT rowid, * FROM users");
            var user_collect = _ct.Users.ToList();
            user_collect.ForEach(f => Console.WriteLine($"{user_collect.IndexOf(f)+1}\t{f.ToString()}"));
            
            Console.WriteLine("INSERT INTO users VALUES('Даша', 2, 24, 1200)");
            User u3 = new User()
            {
                Name = "Даша",
                Sex = false,
                Old = 24,
                Score = 1200
            };
            _ct.Users.Add(u3);
            _ct.SaveChanges();

            user_collect = _ct.Users.ToList();
            Console.WriteLine($"какой rowid?\n\tОтвет:{user_collect.IndexOf(u3) + 1}");
        }  
        
        static void Task_11()
        {
            var u_s = _ct.Users.ToList();
            
            u_s.ForEach(a =>
            {
                Game g1 = new Game()
                {
                    Score = 300,
                    Time = DateTime.Now,
                    User = a
                };
                
                Game g2 = new Game()
                {
                    Score = 1300,
                    Time = DateTime.Now,
                    User = a
                };
                
                Game g3 = new Game()
                {
                    Score = 2300,
                    Time = DateTime.Now,
                    User = a                    
                };

                _ct.Games.AddRange(g1, g2, g3);                
            });

            _ct.SaveChanges();

            Console.WriteLine("Данные внесены!");
        }
        
        static void Task_12()
        {
            var common_collect = _ct.Games.Where(w => w.User_Id == 1).ToList();
            Console.WriteLine("SELECT count(user_id) FROM games WHERE user_id = 1" +
                              $"\n\tОтвет: {common_collect.Count}");
            
            Console.WriteLine("SELECT count() as count FROM games WHERE user_id = 1" +
                              $"\n\tОтвет: {common_collect.Count}");               
        }
        
        static void Task_13()
        {
            var common_collect = _ct.Games.ToList();
            
            Console.WriteLine("SELECT DISTINCT user_id FROM games");
            common_collect
                .OrderByDescending(ob => ob.User_Id)
                .ToList()
                .ForEach(f => Console.WriteLine(f.ToString()));

            Console.WriteLine("SELECT count(DISTINCT user_id) as count FROM games" +
                              $"\n\tОтвет: {common_collect.OrderByDescending(ob => ob.User_Id).Count()}");

            Console.WriteLine("SELECT sum(score) as sum FROM games WHERE user_id = 1" +
                              $"Ответ: {common_collect.Where(w => w.User_Id == 1).Sum(s => s.Score)}");

            Console.WriteLine("SELECT max(score) FROM games WHERE user_id = 1" +
                              $"Ответ: {common_collect.Where(w => w.User_Id == 1).Max(m => m.Score)}");
            Console.WriteLine("SELECT min(score) FROM games WHERE user_id = 1" +
                              $"Ответ: {common_collect.Where(w => w.User_Id == 1).Min(m => m.Score)}");            
        }
        
        static void Task_14()
        {
            Console.WriteLine("SELECT user_id, sum(score) as sum FROM games GROUP BY user_id");
            Console.WriteLine(string.Join("\n",
                _ct
                    .Games
                    .GroupBy(gb => gb.User_Id)
                    .Select(s => new
                    {
                        user_id = s.Key,
                        sum = s.Sum(s_ => s_.Score)
                    })
                    .ToList()
                    .Select(s => $"{s.user_id}\t{s.sum}")));            
        }
        
        static void Task_15()
        {
            Console.WriteLine("SELECT user_id, sum(score) as sum FROM games WHERE score > 300 GROUP BY user_id ORDER BY sum DESC");
            _ct
                .Games
                .Where(w => w.Score > 300)
                .GroupBy(gb => gb.User_Id)
                .Select(s => new
                {
                    user_id = s.Key, 
                    sum = s.Sum(s_ => s_.Score)
                })
                .OrderByDescending(ob => ob.sum)
                .ToList()
                .ForEach(f => Console.WriteLine($"{f.user_id}\t{f.sum}"));
        }

        static void Task_16() =>
            Console.WriteLine("Что изменится если добавить в конце LIMIT 1?" +
                              "\n Ответ: получение первой записи из таблицы.");        
        
        static void Task_17()
        {
            var u_s = _ct.Users.ToList();
            var g_s = _ct.Games.ToList();
            
            Console.WriteLine("SELECT name, sex, games.score FROM games JOIN users ON games.user_id = users.rowid");
            g_s
                .Select(s => new
                {
                    name = s.User.Name,
                    sex = s.User.Sex,
                    score = s.Score,
                    user_id = u_s.IndexOf(s.User) + 1
                })
                .ToList()
                .ForEach(f => Console.Write($"{f.name}\t{f.sex}\t{f.score}\t{f.user_id}"));
            
            Console.WriteLine("SELECT name, sex, games.score FROM users, games");
            g_s
                .Select(s => new
                {
                    name = s.User.Name,
                    sex = s.User.Sex,
                    score = s.Score
                })
                .ToList()
                .ForEach(f => Console.WriteLine($"{f.name}\t{f.sex}\t{f.score}"));
        }
        
        static void Task_18()
        {
            var u_s = _ct.Users.ToList();
            var g_s = _ct.Games.ToList();
            
            Console.WriteLine("SELECT name, sex, games.score FROM games JOIN users ON games.user_id = users.rowid");
            g_s
                .Select(s => new
                {
                    name = s.User.Name,
                    sex = s.User.Sex,
                    score = s.Score,
                    user_id = u_s.IndexOf(s.User) + 1
                })
                .ToList()
                .ForEach(f => Console.WriteLine($"{f.name}\t{f.sex}\t{f.score}\t{f.user_id}"));
            
            Console.WriteLine("Аналог оператора INNER JOIN, " +
                              "соединение записей из двух таблиц, " +
                              "если соответствия найдены в обеих из" +
                              " них удалить одну из записей из " +
                              "таблицы users повторить запрос и " +
                              "выполнить SELECT name, sex, games.score" +
                              " FROM games LEFT JOIN users " +
                              "ON games.user_id = users.rowid");
        }
        
        static void Task_19()
        {
            var u_s = _ct.Users.ToList();
            var g_s = _ct.Games.ToList();
            
            Console.WriteLine("SELECT user_id, sum(score) as sum FROM games GROUP BY user_id ORDER BY sum DESC");
            g_s
                .GroupBy(ob => ob.User_Id)
                .OrderByDescending(or => or.Sum(s => s.Score))
                .Select(s => new
                {
                    user_id = s.Key,
                    sum = s.Sum(s_ => s_.Score)
                })
                .ToList()
                .ForEach(f => Console.WriteLine($"{f.user_id}\t{f.sum}"));
            
            Console.WriteLine("SELECT name, sex, sum(games.score) as score FROM games JOIN users ON games.user_id = users.rowid GROUP BY user_id ORDER BY score DESC");
            g_s
                .GroupBy(ob => ob.User_Id)
                .OrderByDescending(or => or.Sum(s => s.Score))
                .Select(s =>
                {
                    User u = u_s.FirstOrDefault(q => q.User_Id == s.Key);
                    return new
                    {
                        name = u.Name,
                        user_id = u_s.IndexOf(u) + 1,
                        sum = s.Sum(s_ => s_.Score),
                        sex = u.Sex
                    };
                })
                .ToList()
                .ForEach(f => Console.WriteLine($"{f.name}\t" +
                                                $"{f.sex}\t" +
                                                $"{f.sum}\t" +
                                                $"{f.user_id}\t"));
        }        
    }
}