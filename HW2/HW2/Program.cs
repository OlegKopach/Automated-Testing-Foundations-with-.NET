/*
Basic of .NET Framework and C#
Практическое задание 
Написать программу, принимающую из командной строки целое число в десятичной системе,
и основание новой системы счисления (от 2 до 20), вывести в консоль преобразованное в эту систему исходное число.*/
namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int receivedNumber = Convert.ToInt32(Console.ReadLine()); //int.Parse(Console.ReadLine());
            Console.Write("Введите систему счисления от 2-20: ");
            int notation = Convert.ToInt32(Console.ReadLine());

            int number = receivedNumber;        // число в десятичной
            Console.WriteLine("Число в 10-й системе = " + number);
            int system = notation;  // основание системы счисления
            string result = "";     // переменная для результата
            int temp = 0;

            if (number > 0)     // условие, что число больше 0
                while (number >= (system - 1))   // цикл, пока число больше самого основания
                {
                    temp = number % system;
                    number = (number - temp) / system;
                    result = Convert.ToString(temp) + result;
                }
            result = Convert.ToString(number) + result;
            Console.WriteLine("Число в " + system + "-й системе = " + result);
            Console.ReadKey(); 
        }
    }
}