using System;

namespace LibrarySimpleGraphCalculator
{
    public class Sinc : BaseFunction
    {
        public Sinc():base("Sinc(x)") { 
        
        }
        public override double Calc(double x)
        {
            return Calculator.Sinc(x);
        }
    }
}
