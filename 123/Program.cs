using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _123
{
    internal class Program
    {

        static string[] employees = { "Avi", "Tom", "James", "Tony", "Sam", "Avi", "Jose", "Abraham", "Timmy", "Jules", "Santiago", "Tom" };

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch(); // создаем новый таймер
            stopwatch.Start(); //запускаем таймер
            tryingLinq();
            tryingShortenedLinq();
            tryingForeach();
            countingTnames();
            repeats();
            stopwatch.Stop(); // останавливаем таймер
            Console.WriteLine("Overall time is " + stopwatch.ElapsedMilliseconds + "ms"); // выводим время выполнения кода в консоль
            Console.ReadKey();

        }

        /// <summary>
        /// Выводит число 100 делённое на 3
        /// </summary>
        static void printinfo()
        {
            var oneHundred= "100";  // создали переменную
            double string_double = Convert.ToInt64(oneHundred) / 3;
            Console.WriteLine(string_double);
            Console.ReadKey();
        }
        /// <summary>
        /// проходимся по списку сотрудников с помощью linq
        /// </summary>
        static void tryingLinq() 
        {
            Stopwatch stopwatch = new Stopwatch(); // создаем новый таймер
            stopwatch.Start(); //запускаем таймер
            var selectedEmployees = from e in employees where e.StartsWith("S") select e; // выбираем всех сотрудников, имена которых начинаются на S, e - временная переменная, кладем их в selectedEmployees
            Console.WriteLine("It's linq"); // выводим "it's linq" в консоль
            foreach (var employee in selectedEmployees) // вводим переменную employee, обозначающую каждый элемент в selectedEmployees
            {
                Console.WriteLine(employee); // выводим в консоль каждого employee из selectedEmployee 
            }
            Thread.Sleep(2000); // спим 2000мс
            stopwatch.Stop(); // останавливаем таймер
            Console.WriteLine("linq S-names is " + stopwatch.ElapsedMilliseconds + "ms"); // выводим время выполнения кода в консоль
            Console.ReadKey(); // ожидаем ввод от пользователя
        }
        /// <summary>
        /// проходимся по списку сотрудников с помощью foreach
        /// </summary>
        static void tryingForeach()
        {
            Stopwatch stopwatch = new Stopwatch(); // создаем новый таймер
            stopwatch.Start(); //запускаем таймер
            var selectedEmployees = new List<string>(); // создаем новый список, в который будем складывать наших сотрудников с заданным критерием
            foreach (var employee in employees) // проходим по списку employees столько раз, сколько имен подходит под заданный критерий
            {
                if (employee.StartsWith("S")) // если имя сотрудника начинается на S,
                {
                    selectedEmployees.Add(employee); // то кладем этого сотрудника в список selectedEmployees
                }
            }
            Console.WriteLine("It's foreach"); // выводим "it's foreach" в консоль
            foreach (var employee in selectedEmployees) // проходим по списку selectedEmployees столько раз, сколько элементов в нем содержится
            {
                Console.WriteLine(employee); // выводим каждого employee в консоль
            }
            Thread.Sleep(2000); // спим 2000мс
            stopwatch.Stop(); // останавливаем таймер
            Console.WriteLine("foreach S-names is " + stopwatch.ElapsedMilliseconds + "ms"); // выводим время выполнения кода в консоль
            Console.ReadKey(); // ожидаем ввод от пользователя
        }
        /// <summary>
        /// проходимся по списку сотрудников с помощью укороченного linq
        /// </summary>
        static void tryingShortenedLinq() 
        {
            Stopwatch stopwatch = new Stopwatch(); // создаем новый таймер
            stopwatch.Start(); //запускаем таймер
            var selectedEmployees = employees.Where(p => p.StartsWith("S"));
            Console.WriteLine("It's shortened linq"); // выводим "it's shortened linq" в консоль
            foreach (var employee in selectedEmployees) // вводим переменную employee, обозначающую каждый элемент в selectedEmployees
            {
                Console.WriteLine(employee); // выводим каждого employee в консоль
            }
            Thread.Sleep(2000); // спим 2000мс
            stopwatch.Stop(); // останавливаем таймер
            Console.WriteLine("shortened linq S-names is " + stopwatch.ElapsedMilliseconds + "ms"); // выводим время выполнения кода в консоль
            Console.ReadKey(); // ожидаем ввод от пользователя
        }

        static void countingTnames()
        { 
            Stopwatch stopwatch = new Stopwatch(); // создаем новый таймер
            stopwatch.Start(); //запускаем таймер
            var tNamesCount = (from e in employees where e.StartsWith("T") select e).Count(); // выбираем имена, начинающиеся на T, и сразу считаем их
            Console.WriteLine("There is " + tNamesCount + " T-names"); // выводим в консоль количество имен, начинающихся на T
            Thread.Sleep(2000); // спим 2000мс
            stopwatch.Stop(); // останавливаем таймер
            Console.WriteLine("counting T-names is " + stopwatch.ElapsedMilliseconds + "ms"); // выводим время выполнения кода в консоль
            Console.ReadKey(); // ожидаем ввод от пользователя
        }
        /// <summary>
        /// Подсчитываем количество повторений в employees
        /// </summary>
        static void repeats() 
        {
            Stopwatch stopwatch = new Stopwatch(); // создаем новый таймер
            stopwatch.Start(); //запускаем таймер
            foreach (var item in employees.Distinct() // Distinct - избавляемся от повторов в конечном результате
                .Where(x => employees.Count(x.Equals) > 1) // проверяем кейсы, в которых имя повторяется > 1 раза
                .Select(x => string.Format("{0} repeats {1} times", x, employees.Count(x.Equals)))) // 0 - имя, 1 - количество повторений
            {
                Console.WriteLine(item); // выводим в консоль наши item
            }
            Thread.Sleep(2000); // спим 2000мс
            stopwatch.Stop(); // останавливаем таймер
            Console.WriteLine("counting repeats is " + stopwatch.ElapsedMilliseconds + "ms"); // выводим время выполнения кода в консоль
            Console.ReadKey(); // ожидаем ввод от пользователя
        }
    }
}