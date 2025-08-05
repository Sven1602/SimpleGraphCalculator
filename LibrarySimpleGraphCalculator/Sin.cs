using System;

namespace LibrarySimpleGraphCalculator
{
    public class Sin : BaseFunction
    {
        public Sin():base("sin(x)") { 
        
        }
        public override double Calc(double x)
        {
            return Calculator.Sin(x);
        }
    }
}
