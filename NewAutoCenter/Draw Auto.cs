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

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewAutoCenter;
using NewAutoCenter.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Center
{
    internal class DrawAuto : MainWindow
    {
        private readonly AutoCenterContext _context;
        private readonly string _login;

        public DrawAuto(AutoCenterContext context, string login) : base(context, login)
        {
            _context = context;
            _login = login;
        }

        public void DrawAllCarsForView()
        {
            var allCarsForVied = _context.CarInMagazines.ToList();

            foreach (var car in allCarsForVied)
            {
                Console.WriteLine($"Марка: {car.Mark}, Модель: {car.Model}, Год выпуска: {car.YearsBorn}, Цена: {car.price}");

                Console.WriteLine("Solaris HS. Известен своей простотой, скоростью, мобильснотью и лёгок в обслуживании");
                Console.WriteLine("\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n............  .:                             \r\n.:^~!!!!!!7777!!!!! ^ ^^^~!77 ?????? 77!~^:.                      \r\n: ~7JJJJ ? !!YPPPGG! ? J ? 7 ? 7 ? Y5PPP5JPGG ? ~~!!7 ? JYJ7 ^.                  \r\n.^ 7JJ ? !~: .....:7PGG! ? GJ77 ? !!P55PP5YYPPY ^::^ 7 ?? J5PPY ? ^: ..             \r\n.~7JJ7~:.....:::^!5PB5~7!755 ?? Y5555555Y5PPYYJ5555YJYJJ7 ^ ^^^::..         \r\n..~7JJJJJ7777777 ? JJY555PP ? !7PG7~!!7JYYYYYYJJJJ ? 77!!~~~^^^^^^^^^~? JY ^        \r\n.......::::::::^ ~~~!!!!777 ???? 7~!5B#GYYYYYJ7!!~~~^~^^^^^^^^^^^^^~~^^^::^~7!        \r\n             ...::::::::::::^^^^^^^^^^^^~^^~~^~~^!777!!~~^^^^^^^^^~~~^^^^^^^^^^~^^^^^^^~~~~~.       \r\n          ..::^^^^^^^^^^^^^^^^^~~!77JYY5J~~^^^^^^^^^^^^^^^^^^^~~~~~~~~~~~~~~~~~~~~~7Y55?~~~!.       \r\n         !!~~~~^^^^^^^^~~!7?JY555P5YGPJ!^^^^^^^^^^^~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!5BBG#&G!!~.       \r\n        ^B&&#P5PGGP555PPGGPGBPPYJYYJ!^^^^!J5GGG5?~~~!~~~~~~~~~~~~~~~~~~~~~~~~~~~~PBPYYYG@J!P7       \r\n        :GBGBPGB&&@@@&&#57!!!~~~~~^:^^^!P#&&##&&@B7~~~~~~~~~~!~~~~~~~~~~~~~~~~~~Y#PYJYJ5&5JJ.       \r\n        .?PJY55YJ5&&&#57~~~~~~~!^^~~~~?B##G5PYPB#@#!~!~~~~~^^^^^^^^^^^~~~~!!!!!7##PYJYJP!:.         \r\n        ^Y5PGGGGPG&#5!~~~~!!!JGB?~~~~7###5P5JPJJB#@5~!~^^^^~~~~!!!!7777??????7J&@@B555GJ            \r\n        ^JPGGGGGGGPY???!~~~~!5PPG?~~~5&#PYYJ?Y5?P&@#!77777?????JJJJJJJJJJJJ????YGB#BG5!.            \r\n          .:^~!7J5PGP55Y?~^^^^~~7?~~!B&&P55?YYY?B##PJJJJJJJJJ????77!!~~~^^::::.......               \r\n              ..:^!?J??????????????JP@@&#YJJPJYB#J???77!!!~~^^:::....                               \r\n          ...:^^~~~!!77?????JJJJJJJJ5B&@@@#BB##5~^^::....                                           \r\n             .....:::^^^^^~~~~~~~~~~~~!7?JJJ?~:                                                     \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ");
            
                Console.ReadKey();

                Console.WriteLine("Solaris KRS. Почти тоже самое, но эта машина выглядит более спортивнее");

                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n.                                 \r\n...::::^ ^^^^^~7 ? JJJYYY ?? 7!~^:.                            \r\n...::::^ ^~~!? !~!JJ ? Y5GGGPBB ? JYYY5P5Y! :.                        \r\n..:^^^^^^~~~~!7 ? !!JJJ!~!5BBBPGBPGG55GPPGG7~^:..                    \r\n......:^:::::^^^^~~~~^^JG5J ?????? 77!!7!!!!!!~~~!~~~~~~!7!.                \r\n...........::::^ ~!!~::::::::~^~~~^::::::~~^^:::^^^^^~~~~~~~!? 5!                \r\n: J ? !?? 7777!!7JP55JY ? !^::::::::::^ ^: ^^^^::::^ ^^^^^^^^^^~^^^^~!~~~~~~                \r\n ? BGPPB#BGPY?JJJ?PP!^^^^?5GGG57::^^^^^^^^^^^~~~~~~~~~~~~~~?G#&#5!~~!.               \r\n                :~!~~~7^:::^^^^~?!~^~^7B&#BBB&@P~^^^^^^~~~~~~~~^~^^^^^^~~J&BP5G@G!!!.               \r\n                ?GPP55PJJ??!~~~P&7~~~?&&GYYJJYB@5^~^^^^^^^^^^~~~~~~~~!!!!&#5JJJG@7~~.               \r\n               .YB#&&@&#&&P5BJ~!P!~~^G@BYJ?J5?P@&!~~~~~~~~!!!~~~~~~~~~775@#5JYYP?::.....            \r\n             ...:^^~!?G#&#B##BY!~~~~!#&#YJ?YYJBB5!!!!!77?5GBGJ77777777??P&@#PPG5~^^^:::....         \r\n        .........::^^~75B###GYJJJJJJYB&&#5555BB555PPPPPPP5555YJ???????????JYYJ?!!~~~^^:::....       \r\n       .......:::^^~!777??????JJJJYYYJY5PP55Y?777!!!~~~~~^^^^^^^::::::::::::::::::::.......         \r\n            ........::::::::::::::^^^^^^^^::::::::::::::::::.......................                 \r\n                    ...............:::::::::..................                                      \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ");

                return;
            }
        }
        
        public void DrawAllCars()//рисовка авто
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

        public void SellCar(string model, int amount) //продажа авто 
        {
            var priceCar = _context.CarInMagazines.FirstOrDefault(u => u.Model == model);
            if (priceCar != null) {
                Console.WriteLine($"Итак вы выбрали: {model}. С вас {priceCar.price}");
                Cash_Users cashForPrice = new Cash_Users(_context, _login);
                cashForPrice.SellCarsAndUseUsers(amount, model);
                
            }
        }

        public void QuentityCar(int amount, string model) //вычитание количества
        {
            var quentityCar = _context.CarInMagazines.FirstOrDefault(u => u.Model == model);
            if (quentityCar != null)
            {
                Cash_Users cashForQuentity = new Cash_Users(_context, _login);
                cashForQuentity.QuentityCar(model);
            }
        }

        public void DrawOneCar(string model)
        {
            bool isOpenPage = true;

            while (isOpenPage)
            {
                switch (model)
                {
                    case "HS":
                        string drawHS = "\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                       ............  .:                             \r\n                                      .:^~!!!!!!7777!!!!!^^^^~!77??????77!~^:.                      \r\n                                   :~7JJJJ?!!YPPPGG!?J?7?7?Y5PPP5JPGG?~~!!7?JYJ7^.                  \r\n                               .^7JJ?!~:.....:7PGG!?GJ77?!!P55PP5YYPPY^::^7??J5PPY?^:..             \r\n                            .~7JJ7~:.....:::^!5PB5~7!755??Y5555555Y5PPYYJ5555YJYJJ7^^^^::..         \r\n                        ..~7JJJJJ7777777?JJY555PP?!7PG7~!!7JYYYYYYJJJJ?77!!~~~^^^^^^^^^~?JY^        \r\n                 .......::::::::^~~~!!!!777????7~!5B#GYYYYYJ7!!~~~^~^^^^^^^^^^^^^~~^^^::^~7!        \r\n             ...::::::::::::^^^^^^^^^^^^~^^~~^~~^!777!!~~^^^^^^^^^~~~^^^^^^^^^^~^^^^^^^~~~~~.       \r\n          ..::^^^^^^^^^^^^^^^^^~~!77JYY5J~~^^^^^^^^^^^^^^^^^^^~~~~~~~~~~~~~~~~~~~~~7Y55?~~~!.       \r\n         !!~~~~^^^^^^^^~~!7?JY555P5YGPJ!^^^^^^^^^^^~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~!5BBG#&G!!~.       \r\n        ^B&&#P5PGGP555PPGGPGBPPYJYYJ!^^^^!J5GGG5?~~~!~~~~~~~~~~~~~~~~~~~~~~~~~~~~PBPYYYG@J!P7       \r\n        :GBGBPGB&&@@@&&#57!!!~~~~~^:^^^!P#&&##&&@B7~~~~~~~~~~!~~~~~~~~~~~~~~~~~~Y#PYJYJ5&5JJ.       \r\n        .?PJY55YJ5&&&#57~~~~~~~!^^~~~~?B##G5PYPB#@#!~!~~~~~^^^^^^^^^^^~~~~!!!!!7##PYJYJP!:.         \r\n        ^Y5PGGGGPG&#5!~~~~!!!JGB?~~~~7###5P5JPJJB#@5~!~^^^^~~~~!!!!7777??????7J&@@B555GJ            \r\n        ^JPGGGGGGGPY???!~~~~!5PPG?~~~5&#PYYJ?Y5?P&@#!77777?????JJJJJJJJJJJJ????YGB#BG5!.            \r\n          .:^~!7J5PGP55Y?~^^^^~~7?~~!B&&P55?YYY?B##PJJJJJJJJJ????77!!~~~^^::::.......               \r\n              ..:^!?J??????????????JP@@&#YJJPJYB#J???77!!!~~^^:::....                               \r\n          ...:^^~~~!!77?????JJJJJJJJ5B&@@@#BB##5~^^::....                                           \r\n             .....:::^^^^^~~~~~~~~~~~~!7?JJJ?~:                                                     \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ";
                        Console.WriteLine(drawHS);

                        Console.WriteLine("Желаете купить: ");

                        Console.WriteLine("Поля для ввода: ");

                        string answer = Console.ReadLine();


                        if (answer == "yes" || answer == "y" || answer == "да" || answer == "Y" || answer == "Yes" || answer == "Да")
                        {
                            while (true)
                            {
                                Console.WriteLine("Желаете пополнить баланс?");
                                Console.Write("Поля для ввода: ");
                                
                                string sellAnswer = Console.ReadLine();

                                if (sellAnswer== "no" || sellAnswer == "No" || sellAnswer == "n" || sellAnswer == "N" || sellAnswer == "нет" || sellAnswer == "Нет")
                                {
                                    var price = _context.CarInMagazines.SingleOrDefault(u => u.Model == model);

                                    price.price = price.price.Replace(" ", "").Replace("рублей", "");

                                    int priceAsInt = int.Parse(price.price);

                                    int quentityInt = int.Parse(price.quentity); 

                                    SellCar(model, priceAsInt);
                                    QuentityCar(quentityInt, model);
                                }

                                else if (sellAnswer == "yes" || sellAnswer == "y" || sellAnswer == "да" || sellAnswer == "Y" || sellAnswer == "Yes" || sellAnswer == "Да")
                                {
                                    Cash_Users cash = new Cash_Users(_context, _login);

                                    cash.AddCash();

                                    var price = _context.CarInMagazines.SingleOrDefault(u => u.Model == model);

                                    price.price = price.price.Replace(" ", "").Replace("рублей", "");

                                    int priceAsInt = int.Parse(price.price);

                                    int quentityInt = int.Parse(price.quentity);

                                    SellCar(model, priceAsInt);
                                    QuentityCar(quentityInt, model);
                                }
                                Console.ReadKey();
                                Console.Clear();

                            }
                        }

                        else if (answer == "no" || answer == "No" || answer == "n" || answer == "N" || answer == "нет" || answer == "Нет")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "KRS":
                        string drawKRS = "\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                  .                                 \r\n                                          ...::::^^^^^^~7?JJJYYY??7!~^:.                            \r\n                                     ...::::^^~~!?!~!JJ?Y5GGGPBB?JYYY5P5Y!:.                        \r\n                                 ..:^^^^^^~~~~!7?!!JJJ!~!5BBBPGBPGG55GPPGG7~^:..                    \r\n                          ......:^:::::^^^^~~~~^^JG5J??????77!!7!!!!!!~~~!~~~~~~!7!.                \r\n                     ...........::::^~!!~::::::::~^~~~^::::::~~^^:::^^^^^~~~~~~~!?5!                \r\n                 :J?!??7777!!7JP55JY?!^::::::::::^^:^^^^::::^^^^^^^^^^^~^^^^~!~~~~~~                \r\n                 ?BGPPB#BGPY?JJJ?PP!^^^^?5GGG57::^^^^^^^^^^^~~~~~~~~~~~~~~?G#&#5!~~!.               \r\n                :~!~~~7^:::^^^^~?!~^~^7B&#BBB&@P~^^^^^^~~~~~~~~^~^^^^^^~~J&BP5G@G!!!.               \r\n                ?GPP55PJJ??!~~~P&7~~~?&&GYYJJYB@5^~^^^^^^^^^^~~~~~~~~!!!!&#5JJJG@7~~.               \r\n               .YB#&&@&#&&P5BJ~!P!~~^G@BYJ?J5?P@&!~~~~~~~~!!!~~~~~~~~~775@#5JYYP?::.....            \r\n             ...:^^~!?G#&#B##BY!~~~~!#&#YJ?YYJBB5!!!!!77?5GBGJ77777777??P&@#PPG5~^^^:::....         \r\n        .........::^^~75B###GYJJJJJJYB&&#5555BB555PPPPPPP5555YJ???????????JYYJ?!!~~~^^:::....       \r\n       .......:::^^~!777??????JJJJYYYJY5PP55Y?777!!!~~~~~^^^^^^^::::::::::::::::::::.......         \r\n            ........::::::::::::::^^^^^^^^::::::::::::::::::.......................                 \r\n                    ...............:::::::::..................                                      \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ";
                        Console.WriteLine(drawKRS);

                        Console.WriteLine("Желаете купить: ");

                        Console.WriteLine("Поля для ввода: ");

                        answer = Console.ReadLine();

                        if (answer == "yes" || answer == "y" || answer == "да" || answer == "Y" || answer == "Yes" || answer == "Да")
                        {
                            while (true)
                            {
                                Cash_Users cash = new Cash_Users(_context, _login);

                                cash.AddCash();
                            }
                        }

                        else if (answer == "no" || answer == "No" || answer == "n" || answer == "N" || answer == "нет" || answer == "Нет")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.ReadKey();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Нет рисунка для данной модели.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}