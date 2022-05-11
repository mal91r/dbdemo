using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_demo
{
    public class Operations
    {
        public static void Add()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
                //db.Challenges.AddRange(new Challenge { Title = "Hse Run"}, new Challenge { Title = "CSGO Camp"});
                Console.WriteLine("Введите количество новых пользователей");
                int.TryParse(Console.ReadLine(), out int n);
                // создание и добавление моделей
                string name;
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Введите имя пользователя: ");
                    name = Console.ReadLine();
                    User user = new User { Name = name };
                    db.Users.Add(user);
                    user.Challenges.AddRange(db.Challenges);
                    Console.WriteLine("Пользователь добавлен!");
                }
                db.SaveChanges();
            }
        }
        public static void Print()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Challenges.Include(c => c.Members).ToList();
                // выводим все курсы
                foreach (var c in courses)
                {
                    Console.WriteLine($"Challenge: {c.Title}");
                    // выводим всех студентов для данного кура
                    foreach (User s in c.Members)
                        Console.WriteLine($"Name: {s.Name}");
                    Console.WriteLine("-------------------");
                }
            }
        }
        public static void Print1()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Challenges.Include(c => c.Members).ToList();
                // выводим все курсы
                foreach (var c in courses)
                {
                    Console.WriteLine($"Course: {c.Title}");
                    // выводим всех студентов для данного кура
                    foreach (var s in c.Enrollments)
                        Console.WriteLine($"Name: {s.User?.Name}  Mark: {s.isCompleted}");
                    Console.WriteLine("-------------------");
                }
            }
        }
    }
}
