//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Auto_Center
//{
//    internal class DrawAuto
//    {
//        private readonly AutoCenterContext _context;

//        public DrawAuto(AutoCenterContext context)
//        {
//            _context = context;

//        }

//        public void DrawAllCars()
//        {
//            // Получаем список всех машин из контекста
//            var allCars = _context.CarInMagazines.ToList();

//            // Выводим каждую машину с указанием марки, модели и года выпуска
//            foreach (var car in allCars)
//            {
//                Console.WriteLine($"Марка: {car.Mark}, Модель: {car.Model}, Год выпуска: {car.YearsBorn}, цена: {car.price}");
//            }

//            Console.WriteLine("\nВыберите любую машину:");
//            Console.Write("Поля для ввода: ");
//            string answer = Console.ReadLine();

//            var checkAuto = _context.CarInMagazines.SingleOrDefault(u => u.Model == answer);

//            if (checkAuto == null)
//            {
//                Console.WriteLine("Машина не найдена.");
//                return;
//            }

//            else
//            {
//                Console.WriteLine($"Вот так выглядит ваша: {checkAuto.Model}");

//                if (checkAuto.Model == answer)
//                {
//                    DrawOneCar();
//                }
//            }

//        }
//        public void DrawOneCar()
//        {

//           string drawHS = "       *********     \n" +
//                         "      *         *    \n" +
//                         "  ****          **** \n" +
//                         "**@@@           @@@ *\n" +
//                         "**@@@           @@@ *\n";

//            Console.WriteLine(drawHS);

//        }
//    }
//}

using NewAutoCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Center
{
    internal class DrawAuto
    {
        private readonly AutoCenterContext _context;

        public DrawAuto(AutoCenterContext context)
        {
            _context = context;
        }

        public void DrawAllCars()
        {
            // Получаем список всех машин из контекста
            var allCars = _context.CarInMagazines.ToList();

            // Выводим каждую машину с указанием марки, модели и года выпуска
            foreach (var car in allCars)
            {
                Console.WriteLine($"Марка: {car.Mark}, Модель: {car.Model}, Год выпуска: {car.YearsBorn}, Цена: {car.price}");
            }

            Console.WriteLine("\nВыберите любую машину:");
            Console.Write("Поле для ввода: ");
            string answer = Console.ReadLine();

            var checkAuto = _context.CarInMagazines.SingleOrDefault(u => u.Model == answer);

            if (checkAuto == null)
            {
                Console.WriteLine("Машина не найдена.");
                return;
            }

            else
            {
                Console.WriteLine($"Вот так выглядит ваша: {checkAuto.Model}");
                DrawOneCar(checkAuto.Model);
            }
        }

        public void DrawOneCar(string model)
        {
            switch (model)
            {
                case "HS":
                    string drawHS = "       *********     \n" +
                                    "      *         *    \n" +
                                    "  ****************** \n" +
                                    "** @             @  *\n" +
                                    "**@@@           @@@ *\n" +
                                    "** @             @  *\n";
                    Console.WriteLine(drawHS);
                    break;

                case "KRS":
                    string drawKRS = "       *********     \n" +
                                    "      *   KIO    *    \n" +
                                    "  ****************** \n" +
                                    "   @             @   \n";
                    Console.WriteLine(drawKRS);
                    break;
                default:
                    Console.WriteLine("Нет рисунка для данной модели.");
                    break;
            }
        }
    }
}