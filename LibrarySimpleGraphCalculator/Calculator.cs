using System;

namespace LibrarySimpleGraphCalculator
{
    public static class Calculator
    {
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }

        public static double Sin(double x)
        {
            return Math.Sin(x);
        }

        public static double Sinc(double x)
        {
            return x == 0 ? 1.0 : Math.Sin(x) / x;
        }

        public static double Radians(double degrees)
        {
            // Convert degrees to radians
            double radians = degrees * Math.PI / 180;
            return radians;
        }
    }
}
