using System;

namespace LibrarySimpleGraphCalculator
{
    public class ChartData
    {
        public ChartData() { }

        public string Name { get; set; }

        public Func<double, double> Function { get; set; }

        public int MinXValue { get; set; }

        public int MaxXValue { get; set; }

        public double RadIncrement {  get; set; }
    }
}
