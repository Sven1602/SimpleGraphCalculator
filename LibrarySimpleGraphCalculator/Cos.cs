using System;

namespace LibrarySimpleGraphCalculator
{
    public class Cos : BaseFunction
    {
        public Cos():base("cos(x)") { 
        
        }

        public override double Calc(double x)
        {
            return Calculator.Cos(x);
        }
    }
}
