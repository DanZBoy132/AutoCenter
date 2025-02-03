using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Win32.SafeHandles;
using BCrypt.Net;
using System.Numerics;
using NewAutoCenter;
using System.Globalization;

namespace Auto_Center
{
    internal class Program
    {
        static void ColorConsole()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }
        static void Main(string[] args)
        {
            ColorConsole();

            Console.Title = "Автоцентр Solaris";

            string login = "";
            
            string input = "";
            bool isOpen = true;

            while (isOpen)
            {
                using (var context = new AutoCenterContext())
                {
                    MainWindow main = new MainWindow(context, login);
                    DrawAuto draw = new DrawAuto(context, login);

                    main.Menu(isOpen, input);

                    //main.Menu(isOpen, input);

                }
            }
        }
    } //Scaffold-DbContext "Host=localhost;Port=5432;Database=Auto_Center;Username=postgres;Password=7520"
    //Scaffold-DbContext "Host=localhost;Port=5432;Database=Auto_Center;Username=postgres;Password=7520" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Entities -Force
    //Npgsql.EntityFrameworkCore.PostgreSQL

    class MainWindow
    {
        private readonly AutoCenterContext _context;
        private string _login;
        private string _password;

        public MainWindow(AutoCenterContext context, string login)
        {
            _context = context;
            _login = login;
        }

        public void Register()
        {
            Console.WriteLine("Добро пожаловать на регистрацию в автоцентре Solaris");
            Console.Write("Введите ваш ФИО: ");
            string fio = Console.ReadLine();
            Console.Write("Введите логин: ");
            _login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            _password = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(_login) || string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(fio))
            {
                Console.WriteLine("Логин и пароль не могут быть пустыми.");
                return;
            }

            if (_context.Users.Any(u => u.Login == _login))
            {
                Console.WriteLine("Пользователь с таким логином уже существует.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(_password);

            var data = new User
            {
                Login = _login,
                Password = hashedPassword,
                Fio = fio
            };

            _context.Users.Add(data);
            _context.SaveChanges();
            Console.WriteLine("Добро пожаловать в автоцентр");
            InAccount();
        }

        public void Autotization()
        {
            AutoCenterContext context = new AutoCenterContext();

            Console.WriteLine("Добро пожаловать на авторизацию!");
            Console.Write("Введите ваш логин: ");
            _login = Console.ReadLine();
            Console.Write("Введите ваш пароль: ");
            _password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(_login) || string.IsNullOrWhiteSpace(_password))
            {
                Console.WriteLine("Логин и пароль не могут быть пустыми.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            var user = _context.Users.SingleOrDefault(u => u.Login == _login);
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(_password, user.Password))
            {
                Console.WriteLine("Авторизация прошла успешно.");
                InAccount();

                Console.ReadKey();
                Console.Clear();
                return;

            }

            else
            {
                Console.WriteLine("Неверный логин или пароль!");

                Console.ReadKey();
                Console.Clear();
                return;
            }

            
        }

        public void Menu(bool isOpen, string input)
        {
            while (isOpen)
            {
                Console.Write("Добрый день! Приветствую вас в наше автоцентре Solaris." +
                    "\nДля начала пройдите регистрацию для покупки или можете просто посмотреть." +
                    "\nЧто выбираете: 1.Регистрация." +
                    "\n2. Просмотр\n");
                input = Console.ReadLine();

                bool isOpenMenu = true;

                Cash_Users cash = new Cash_Users(_context, _login);

                while (isOpenMenu)
                {
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Вы зарегистрированы?");
                            Console.Write("Поля для ввода: ");

                            
                            string answer = Console.ReadLine();

                            if (answer == "yes" || answer == "y" || answer == "да" || answer == "Y" || answer == "Yes" || answer == "Да")
                            {
                                while (true) 
                                { 
                                    Autotization(); 
                                    
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }

                            else if (answer == "no" || answer == "No" || answer == "n" || answer == "N" || answer == "нет" || answer == "Нет")
                            {
                                while (true) { Register(); Console.Clear(); Console.ReadKey(); }
                            }
                            break;

                        case "2":
                            Console.WriteLine("Начнем");

                            Console.WriteLine("Для продолжения нажмите любую кнопку");

                            DrawAuto draw = new DrawAuto(_context, _login);

                            draw.DrawAllCarsForView();

                            Console.ReadKey();

                            Console.WriteLine("Пока это все машины в нашем автоцентре");
                            Console.WriteLine("Желаете преобрести?");
                            Console.WriteLine("Поля для ввода: ");

                            string answerAuto = Console.ReadLine();

                            if (answerAuto == "yes" || answerAuto == "y" || answerAuto == "да" || answerAuto == "Y" || answerAuto == "Yes" || answerAuto == "Да")
                            {
                                Console.WriteLine("Вы зарегистрированы?");
                                Console.Write("Поля для ввода: ");

                                if (answerAuto == "yes" || answerAuto == "y" || answerAuto == "да" || answerAuto == "Y" || answerAuto == "Yes" || answerAuto == "Да")
                                {
                                    while (true)
                                    {
                                        Autotization();

                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }

                                else if (answerAuto == "no" || answerAuto == "No" || answerAuto == "n" || answerAuto == "N" || answerAuto == "нет" || answerAuto == "Нет")
                                {
                                    while (true) { Register(); Console.Clear(); Console.ReadKey(); }
                                }
                            }

                            else if (answerAuto == "no" || answerAuto == "No" || answerAuto == "n" || answerAuto == "N" || answerAuto == "нет" || answerAuto == "Нет")
                            {
                                Console.WriteLine("Прощайте!!!");
                                isOpen = false;
                            }

                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Неверный ввод");

                            continue;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void AddBalance()
        {
            using (var context = new AutoCenterContext())
            {
                Cash_Users cash = new Cash_Users(context, _login);
                cash.AddCash();
            }
        }
        
        public void InAccount()
        {
            Console.WriteLine("Наш список авто: ");
            using (var context = new AutoCenterContext())
            {
                DrawAuto draw = new DrawAuto(context, _login);
                
                draw.DrawAllCars();
            }
        }

    }
}
