using System;

namespace Algorithms.FinancialForecasting
{
    class Program
    {
        // linear recursion has O(N) stack call frame overhead
        public static double ForecastRec(double principal, double rate, int years)
        {
            if (years <= 0) return principal;
            return ForecastRec(principal, rate, years - 1) * (1 + rate);
        }

        // loop implementation is memory optimized, constant space O(1)
        public static double ForecastIter(double principal, double rate, int years)
        {
            double value = principal;
            for (int i = 0; i < years; i++)
            {
                value *= (1 + rate);
            }
            return value;
        }

        static void Main()
        {
            double pv = 1000.0;
            double growth = 0.05; // 5%
            int time = 5;

            Console.WriteLine($"Recursive: {ForecastRec(pv, growth, time):F2}");
            Console.WriteLine($"Iterative: {ForecastIter(pv, growth, time):F2}");
        }
    }
}