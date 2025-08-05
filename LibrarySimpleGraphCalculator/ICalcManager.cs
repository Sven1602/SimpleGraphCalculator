namespace LibrarySimpleGraphCalculator
{
    public interface ICalcManager
    {
        double CalculateWithDegree(BaseFunction baseFunction, double degrees);

        double CalculateWithRad(BaseFunction baseFunction, double rad);
    }
}
