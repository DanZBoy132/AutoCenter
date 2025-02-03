using Auto_Center;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NewAutoCenter
{
    //class Cash_Users : MainWIndow
    //{
    //    private readonly AutoCenterContext _context;
    //    public Cash_Users(string input, AutoCenterContext context, string password, string login) : base(input, context, password, login)
    //    {
    //        _context = context;
    //    }

    //    public void AddCash()
    //    {
    //        Console.WriteLine("На сколько хотите пополнить ваш счет?");
    //        Console.WriteLine("Наш выбор:\n1. миллион.\n2. два миллион.\n3. своя сумма");
    //        Console.Write("Поля для ввод: ");

    //        string answer = Console.ReadLine();

    //        //while (true)
    //        //{
    //        switch (answer)
    //        {
    //            case "1":
    //                OneMillion();
    //                break; // миллион
    //            case "2":

    //                break; // два миллион
    //            case "3":

    //                break; // своя сумма
    //            default:

    //                break; // неверный ввод
    //        }

    //        //    Console.Clear();
    //        //    Console.ReadKey();
    //        //}
    //    }

    //    public void OneMillion()
    //    {
    //        //var account = new User
    //        //{
    //        //    Cash = amount
    //        //};

    //        //_context.Users.UpdateRange(account);
    //        //_context.SaveChanges();
    //        //Console.WriteLine("МУжчина");

    //        var data = new User()
    //        {
    //            Login = login
    //        };

    //        if (_context.Users.Any(u => u.Login == login))
    //        {
    //            using (var context = new AutoCenterContext())
    //            {
    //                if (_context.Users.Any(u => u.Login == login))
    //                {
    //                    // Получаем запись по идентификатору
    //                    var entity = context.Users.Find(login);

    //                    if (entity != null)
    //                    {
    //                        // Обновляем нужное свойство
    //                        entity.Cash = 1000000;

    //                        // Сохраняем изменения
    //                        context.SaveChanges();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    public class Cash_Users
    {
        private readonly AutoCenterContext _context;
        private readonly string _login;

        public Cash_Users(AutoCenterContext context, string login)
        {
            _context = context;
            _login = login;
        }

        public void AddCash()
        {
            Console.WriteLine("На сколько хотите пополнить ваш счет?");
            Console.WriteLine("Наш выбор:\n1. миллион.\n2. два миллиона.\n3. своя сумма");
            Console.Write("Поля для ввода: ");

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    OneMillion();
                    break; // миллион
                case "2":
                    TwoMillions();
                    break; // два миллиона
                case "3":
                    CustomAmount();
                    break; // своя сумма
                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }

        private void OneMillion()
        {
            UpdateBalance(1000000);
        }

        private void TwoMillions()
        {
            UpdateBalance(2000000);
        }

        private void CustomAmount()
        {
            Console.Write("Введите сумму: ");
            int customAmount = int.Parse(Console.ReadLine());
            UpdateBalance(customAmount);
        }

        private void UpdateBalance(int amount)
        {
            if (_context.Users.Any(u => u.Login == _login))
            {
                var user = _context.Users.Single(u => u.Login == _login);
                user.Cash += amount;
                _context.SaveChanges();
                Console.WriteLine($"Счет пополнен на {amount}. Текущий баланс: {user.Cash}");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }
        }

        public void SellCarsAndUseUsers(int amount, string model)
        {
            var sellCar = _context.CarInMagazines.SingleOrDefault (u => u.Model== model);
            
            if ( _context.Users.Any( u => u.Login == _login))
            {
                var user = _context.Users.Single( u => u.Login == _login);

                if (user.Cash < amount)
                {
                    Console.WriteLine("Недостаточно средств, попробуйте после пополнения!");
                }

                else
                {
                    user.Cash -= amount;
                    _context.SaveChanges();
                    Console.WriteLine($"Покупка прошла успешно! У вас теперь есть {sellCar.Model}, ваш отстаток {user.Cash}");
                }
            }
        }

        public void QuentityCar(string model)
        {
            using (var context = new AutoCenterContext())
            {
                var car = context.CarInMagazines.FirstOrDefault(c => c.Model == model);

                if (car != null)
                {
                    int currentQuantity = int.Parse(car.quentity);

                    if (currentQuantity > 0)
                    {
                        currentQuantity--;
                        car.quentity = currentQuantity.ToString(); // Обновляем количество
                        context.SaveChanges(); // Сохраняем изменения в базу данных

                        Console.WriteLine($"Осталось машин модели {car.Model} в количестве {currentQuantity} штук.");
                    }
                    else
                    {
                        Console.WriteLine($"Машины модели {car.Model} больше нет в наличии.");
                    }
                }
                else
                {
                    Console.WriteLine($"Модель {model} не найдена в базе данных.");
                }
            }
        }
    }



        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        AutoCenterContext context = new AutoCenterContext(GetDbContextOptions());

        //        Console.WriteLine("Введите логин:");
        //        string login = Console.ReadLine();

        //        Console.WriteLine("Введите пароль:");
        //        string password = ReadPassword();

        //        int? userId = AuthenticateUser(context, login, password);

        //        if (userId.HasValue)
        //        {
        //            Console.WriteLine($"Добро пожаловать, {login}!");
        //            PerformActions(context, userId.Value);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Неверный логин или пароль.");
        //        }
        //    }

        //    private static int? AuthenticateUser(AutoCenterContext context, string login, string password)
        //    {
        //        var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        //        return user?.Id;
        //    } //

        //    private static void PerformActions(AutoCenterContext context, int userId)
        //    {
        //        Console.WriteLine("Введите сумму для пополнения счета:");
        //        int cash = Convert.ToInt32(Console.ReadLine());

        //        UpdateCash(context, userId, cash);
        //    }

        //    private static void UpdateCash(AutoCenterContext context, int userId, int cash)
        //    {
        //        var user = context.Users.Find(userId);

        //        if (user != null)
        //        {
        //            user.Cash += cash;
        //            context.SaveChanges();
        //            Console.WriteLine($"Счет пополнен на {cash}. Текущий баланс: {user.Cash}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Пользователь не найден.");
        //        }
        //    }

        //    private static string ReadPassword()
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        while (true)
        //        {
        //            ConsoleKeyInfo cki = Console.ReadKey(true);
        //            if (cki.Key == ConsoleKey.Enter)
        //            {
        //                Console.WriteLine();
        //                break;
        //            }

        //            if (cki.Key == ConsoleKey.Backspace)
        //            {
        //                if (sb.Length > 0)
        //                {
        //                    Console.Write("\b \b");
        //                    sb.Length--;
        //                }
        //            }
        //            else
        //            {
        //                Console.Write("*");
        //                sb.Append(cki.KeyChar);
        //            }
        //        }
        //        return sb.ToString();
        //    }

        //    private static DbContextOptions<AutoCenterContext> GetDbContextOptions()
        //    {
        //        const string connectionString = "Your_Connection_String_Here";
        //        var optionsBuilder = new DbContextOptionsBuilder<AutoCenterContext>();
        //        optionsBuilder.UseNpgsql(connectionString);
        //        return optionsBuilder.Options;
        //    }
        //}
    }
