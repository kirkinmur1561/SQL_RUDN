using System;
using System.Linq;
using Lab_1.Model;

namespace Lab_1
{
    class Program
    {
        /// <summary>
        /// Объект позволяющий обращаться к БД
        /// </summary>
        private static ContextTask _ct;
        
        static void Main()
        {
            _ct = new ContextTask();
            while (true)
            {
                Console.Write("Введите номер задачи от 1 до 7.\nЕсли нужно закрыть программу нажмите Enter:\n");
                string textPerson = Console.ReadLine();
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
                    case 7:
                        Task_7();       
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
            Console.WriteLine("Очистка БД!");
            _ct.Database.EnsureDeleted();
            _ct.Database.EnsureCreated();
            Console.WriteLine("Таблица создана!");

            #region Создание объектов пользователей
            User u1 = new User()
            {
                Name = "Кот",
                Old = 6,
                Sex = true,
                Score = 300
            };
            
            User u2 = new User()
            {
                Name = "Енот",
                Old = 22,
                Sex = true,
                Score = 305
            };
            
            User u3 = new User()
            {
                Name = "Кашилот",
                Old = 2,
                Sex = false,
                Score = 300
            };
            
            User u4 = new User()
            {
                Name = "Бегемот",
                Old = 33,
                Sex = true,
                Score = 300
            };
            #endregion            

            _ct.Users.AddRange(u1, u2, u3, u4);/*добавление пользователей*/
            _ct.SaveChanges();/*сохранение изм*/
            Console.WriteLine("Пользователи добавлены!");            
        }
        
        static void Task_2()
        {
            var queryable = _ct.Users.Where(w => new[]
            {
                "Алексей",
                "Миша",
                "Федор",
                "Маша"
            }.Contains(w.Name)).ToList(); /*Поиск дубликатов*/

            if (queryable.Count > 0)
            {
                _ct.Users.RemoveRange(queryable);/*удаление дублей*/                
                _ct.SaveChanges();/*сохранение изм*/
            }
            
            #region Создание объектов пользователей
            User u1 = new User()
            {
                Name = "Кот",
                Old = 6,
                Sex = true,
                Score = 300
            };
            
            User u2 = new User()
            {
                Name = "Енот",
                Old = 22,
                Sex = true,
                Score = 305
            };
            
            User u3 = new User()
            {
                Name = "Кашилот",
                Old = 2,
                Sex = false,
                Score = 300
            };
            
            User u4 = new User()
            {
                Name = "Бегемот",
                Old = 33,
                Sex = true,
                Score = 300
            };
            #endregion  

            _ct.Users.AddRange(u1, u2, u3, u4);/*добавление пользователей*/
            _ct.SaveChanges();/*сохранение изм*/
            Console.WriteLine("Пользователи добавлены!");  
        }

        static void Task_3() =>
            Console.WriteLine(string.Join("\n",
                _ct.Users.ToList().Select(s => $"Name:{s.Name} - Old:{s.Old}")));
        /*Запрос к таблице Users
         Получение всех записей
         После получения идет сборка нового объекта коллекции типа string
         коллекция объединяется в строку с сепаратором новой строки
         и вывод на консоль этой новой строки*/


        static void Task_4() =>
            Console.WriteLine(string.Join("\n",
                _ct.Users.Where(w => w.Old > 20).ToList().Select(s => $"Name:{s.Name}")));
        
        /*Запрос к таблице Users
         Получение всех записей по фильтру возраста старше 20
         После получения идет сборка нового объекта коллекции типа string
         коллекция объединяется в строку с сепаратором новой строки
         и вывод на консоль этой новой строки*/

        static void Task_5()
        {
            Console.WriteLine(string.Join("\n",
                _ct.Users.Where(w => w.Old > 20 && w.Score < 1000).ToList()
                    .Select(s => $"Name:{s.Name}\tOld:{s.Old}\tScore:{s.Score}")));

            Console.Write("Нажмите Enter чтобы увидеть сл запрос...");
            Console.ReadLine();
            
            Console.WriteLine(string.Join("\n",
                _ct.Users.Where(w => (w.Old>=19 && w.Old<=32) && w.Score > 300 || w.Sex).ToList()
                    .Select(s => $"Name:{s.Name}\tOld:{s.Old}\tScore:{s.Score}\tSex:{s.Sex}")));
        }
        /*Запрос к таблице Users
         Получение всех записей по фильтру возраста старше 20 и баллов < 1000. 
            фильтр сл запроса: диапозон возраста и кол баллов более 300.
         После получения идет сборка нового объекта коллекции типа string
         коллекция объединяется в строку с сепаратором новой строки
         и вывод на консоль этой новой строки*/



        static void Task_6() => Console.WriteLine(string.Join("\n",
            _ct.Users.Where(w => ((w.Old >= 19 && w.Old <= 32) && w.Sex) || w.Score > 300)
                .ToList()
                .Select(s => $"Name:{s.Name}\tSex:{s.Sex}\tOld:{s.Old}\tScore:{s.Score}")));
        
        /*Запрос к таблице Users
         Получение всех записей по фильтру диапозон возраста от 19 до 32 вкл, пол муж или кол баллов более 300
         После получения идет сборка нового объекта коллекции типа string
         коллекция объединяется в строку с сепаратором новой строки
         и вывод на консоль этой новой строки*/


        static void Task_7() => Console.WriteLine(string.Join("\n",
            _ct.Users.Where(s => s.Score < 1000)
                .OrderBy(ob => ob.Old)
                .ToList()
                .Select(s => $"Old:{s.Old}\tSex:{s.Sex}\tName:{s.Name}\tScore:{s.Score}")));
        
        /*Запрос к таблице Users
         Получение всех записей по фильтру кол баллов менее 1000 и сортировка по возрастанию возраста
         После получения идет сборка нового объекта коллекции типа string
         коллекция объединяется в строку с сепаратором новой строки
         и вывод на консоль этой новой строки*/

    }
}