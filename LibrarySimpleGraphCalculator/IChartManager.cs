namespace LibrarySimpleGraphCalculator
{
    public interface IChartManager
    {
        ChartErrorCode UpdateChart(string name, ChartData chartData);

        ChartErrorCode exportChartToSvg(string FilePath, int width, int height);
    }
}
