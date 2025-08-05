

namespace LibrarySimpleGraphCalculator
{
    public class CalcManager : ICalcManager
    {
        public CalcManager() { }

        public double CalculateWithDegree(BaseFunction baseFunction, double degrees)
        {
            if(baseFunction != null)
            {
                double rad = Calculator.Radians(degrees);
                return baseFunction.Calc(rad);
            }
            else
            {
                return 0.0;
            }
        }

        public double CalculateWithRad(BaseFunction baseFunction, double rad)
        {
            if(baseFunction != null)
            {
                return baseFunction.Calc(rad);
            }
            else
            {
                return 0.0;
            }
        }
    }
}
