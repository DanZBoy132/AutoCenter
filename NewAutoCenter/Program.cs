using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Win32.SafeHandles;
using BCrypt.Net;
using System.Numerics;
using NewAutoCenter;

namespace Auto_Center
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string input = "";
            bool isOpen = true;

            while (isOpen)
            {
                using (var context = new AutoCenterContext())
                {
                    MainWIndow main = new MainWIndow(input, isOpen, context);
                    DrawAuto draw = new DrawAuto(context);

                    main.Menu(isOpen, input);

                    //main.Menu(isOpen, input);
                }
            }
        }
    } //Scaffold-DbContext "Host=localhost;Port=5432;Database=Auto_Center;Username=postgres;Password=7520"
    //Scaffold-DbContext "Host=localhost;Port=5432;Database=Auto_Center;Username=postgres;Password=7520" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Entities -Force
    //Npgsql.EntityFrameworkCore.PostgreSQL

    class MainWIndow
    {
        public string Input;
        public bool IsOpen = true;
        private readonly AutoCenterContext _context;
        private bool _isAuthenticated = false;

        public MainWIndow(string input, bool isOpen, AutoCenterContext context)
        {
            Input = input;
            IsOpen = isOpen;
            _context = context;
        }

        public void Register()
        {
            Console.WriteLine("Добро пожаловать на регистрацию в автоцентре Solaris");
            Console.Write("Введите ваш ФИО: ");
            string fio = Console.ReadLine();
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fio))
            {
                Console.WriteLine("Логин и пароль не могут быть пустыми.");
                return;
            }

            if (_context.Users.Any(u => u.Login == login))
            {
                Console.WriteLine("Пользователь с таким логином уже существует.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var data = new User
            {
                Login = login,
                Password = hashedPassword,
                Fio = fio
            };

            _context.Users.Add(data);
            _context.SaveChanges();
            Console.WriteLine("Добро пожаловать в автоцентр");
            _isAuthenticated = true;
        }

        public void Autotization()
        {
            Console.WriteLine("Добро пожаловать на авторизацию!");
            Console.Write("Введите ваш логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите ваш пароль: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Логин и пароль не могут быть пустыми.");
                return;
            }

            var user = _context.Users.SingleOrDefault(u => u.Login == login);
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден.");
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Console.WriteLine("Авторизация прошла успешно.");
                _isAuthenticated = true;
                return;
            }

            else
            {
                Console.WriteLine("Неверный логин или пароль!");
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
                                Autotization();

                                if (_isAuthenticated = true)
                                {
                                    Console.WriteLine();
                                    InAccount();
                                }
                            }

                            else if (answer == "no" || answer == "No" || answer == "n" || answer == "N" || answer == "нет" || answer == "Нет")
                            {
                                Register();
                                Console.ReadKey();

                                InAccount();
                            }
                            break;

                        case "2":
                            Console.WriteLine("Начнем");

                            Console.WriteLine("Для продолжения нажмите любую кнопку");
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

        public void InAccount()
        {
            Console.WriteLine("Наш список авто: ");
            using (var context = new AutoCenterContext())
            {
                DrawAuto auto = new DrawAuto(context);

                auto.DrawAllCars();
            }
        }

    }
}
