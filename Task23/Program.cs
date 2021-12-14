using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task23
{
    class Program
    {
        // Разработать асинхронный метод для вычисления факториала числа. В методе Main выполнить проверку работы метода. 
        static long n;
        static long CalculateFactorial(long n)
        {
            long factorial = 1;                                                                         // Факториал числа n

            Console.WriteLine("\nНачало вычисления факториала: ");
            for (long i = 0; i <= n; i++)
            {
                if (n == 0 || n == 1)
                {
                    Thread.Sleep(300);
                    Console.WriteLine($"\nФакториал n! числа 0 или 1 всегда будет {factorial}. ");
                    return factorial;
                }
                else
                {
                    do
                    {
                        i++;
                        factorial *= i;
                        Thread.Sleep(500);
                    } while (i != n);
                }
            }
            Console.WriteLine($"\nФакториал найден. ");
            return factorial;
        }
        static async Task<long> CalculateFactorialAsync()
        {
            Console.WriteLine("\nCalculateFactorialAsync начал работу...");

            long result = await Task.Run(() => CalculateFactorial(n));
            Thread.Sleep(1000);

            Console.WriteLine("\nCalculateFactorialAsync окончил работу...");
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите целое неотрицательное число: ");

            try
            {
                n = Convert.ToInt32(Console.ReadLine());

                if (n >= 0)
                {
                    Console.WriteLine("\nФакториал числа равен: {0}.", CalculateFactorialAsync().Result);
                }
                else
                {
                    Console.WriteLine("Значение должно быть целым неотрицательным числом. ");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("\nMain окончил работу...");
            Console.ReadKey();
        }
    }
}
