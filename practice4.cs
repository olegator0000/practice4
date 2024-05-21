// задача 1 [10]
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть число у двійковому форматі: ");
        string binaryNumber = Console.ReadLine();
        CountBinaryDigits(binaryNumber, out int onesCount, out int zerosCount);

        Console.WriteLine($"Кількість одиниць: {onesCount}");
        Console.WriteLine($"Кількість нулів: {zerosCount}");
    }

    static void CountBinaryDigits(string binaryNumber, out int onesCount, out int zerosCount)
    {
        onesCount = 0;
        zerosCount = 0;

        foreach (char digit in binaryNumber)
        {
            if (digit == '1')
            {
                onesCount++;
            }
            else if (digit == '0')
            {
                zerosCount++;
            }
            else
            {
                Console.WriteLine("Помилка: Введено неправильний символ.");
                onesCount = 0;
                zerosCount = 0;
                return;
            }
        }
    }
}

// задача 2 [6]
using System;

class Program
{
    static void Main(string[] args)
    {
        double sum1 = CalculateSeriesSum(0.000001);
        double sum2 = CalculateSeriesSumForFirstTerms(10);

        Console.WriteLine($"Сума членів ряду з точністю до 0.000001: {sum1}");
        Console.WriteLine($"Сума перших 10 членів ряду: {sum2}");
    }

    static double CalculateSeriesSum(double precision)
    {
        double sum = 0;
        double term;
        int n = 0;

        do
        {
            term = Math.Pow(-1, n) * (1 - Math.Pow(n + 1, 2) / Math.Pow(n + 2, 2));
            sum += term;
            n++;
        } while (Math.Abs(term) > precision);

        return sum;
    }

    static double CalculateSeriesSumForFirstTerms(int numberOfTerms)
    {
        double sum = 0;

        for (int i = 0; i < numberOfTerms; i++)
        {
            double term = Math.Pow(-1, i) * (1 - Math.Pow(i + 1, 2) / Math.Pow(i + 2, 2));
            sum += term;
        }

        return sum;
    }
}


// задача 3[6,25]

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть номер варіанту: ");
        int variant = int.Parse(Console.ReadLine());
        double h = 0.1 * variant;

        Console.WriteLine($"Проміжок [0;{variant}] з кроком h = {h}");
        Console.WriteLine(" x       |      y");
        Console.WriteLine("--------------------");

        (double max, int negativeCount) = TabulateFunction(variant, h);

        Console.WriteLine($"Кількість від'ємних значень: {negativeCount}");
        Console.WriteLine($"Максимальне значення функції: {max:F6}");
    }

    static (double, int) TabulateFunction(int upperLimit, double step)
    {
        double max = double.MinValue;
        int negativeCount = 0;

        for (double x = 0; x <= upperLimit; x += step)
        {
            double y = CalculateFunction(x);

            if (y > max)
            {
                max = y;
            }
            if (y < 0)
            {
                negativeCount++;
            }

            Console.WriteLine($"{x,-8:F2} | {y,-10:F6}");
        }

        return (max, negativeCount);
    }

    static double CalculateFunction(double x)
    {
        return Math.Sin(Math.Abs(x - 1.5)) / Math.Log10(Math.Abs(x - 3.7) + 8);
    }
}

// задача 4 [12]
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть натуральне число g: ");
        int g = int.Parse(Console.ReadLine());

        Console.WriteLine($"Розклад числа {g} на прості множники:");
        DecomposeIntoPrimeFactors(g);
    }

    static void DecomposeIntoPrimeFactors(int g)
    {
        for (int i = 2; i <= g; i++)
        {
            int count = 0;
            while (g % i == 0)
            {
                g /= i;
                count++;
            }
            if (count > 0)
            {
                Console.WriteLine($"{i}^{count}");
            }
        }
    }
}
// Задача 1:
//  Винесено логіку підрахунку одиниць і нулів у двійковому числі в метод CountBinaryDigits.
//   Задача 2: 
//   Обчислення суми ряду з точністю до заданого значення та обчислення
//    суми перших 10 членів ряду винесено в методи CalculateSeriesSum і CalculateSeriesSumForFirstTerms.
//     Задача 3: 
//     Табулювання функції винесено в методи TabulateFunction і CalculateFunction.
//      Задача 4:
//       Розклад числа на прості множники винесено в метод DecomposeIntoPrimeFactors.