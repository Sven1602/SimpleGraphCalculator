using LibrarySimpleGraphCalculator;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using System.IO;

namespace SimpleGraphCalculator
{
    public class OxyPlotChartManager : IChartManager
    {
        public OxyPlotChartManager() {

            this.ChartModel = new PlotModel { Title = "Functions", IsLegendVisible = true };
            this.ChartModel.Legends.Add(new Legend
            {
                LegendBackground = OxyColor.FromAColor(220, OxyColors.White),
                LegendBorder = OxyColors.Black,
                LegendBorderThickness = 1.0,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomLeft,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendLineSpacing = 8,
                LegendMaxWidth = 1000,
                LegendFontSize = 12
            });
        }

        public PlotModel ChartModel { get; private set; }

        public ChartErrorCode exportChartToSvg(string FilePath, int width, int height)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                using (var stream = File.Create(FilePath))
                {
                    var exporter = new SvgExporter { Width = width, Height = height };
                    exporter.Export(ChartModel, stream);
                }
            }
            else
            {
                return ChartErrorCode.filePathNotFound;
            }

            return ChartErrorCode.ok;
        }

        public ChartErrorCode UpdateChart(string name, ChartData chartData)
        {
            if(ChartModel != null)
            {
                if (!string.IsNullOrEmpty(name) && chartData != null)
                {
                    this.ChartModel.Series.Clear();
                    this.ChartModel.Title = name;
                    this.ChartModel.Series.Add(new FunctionSeries(chartData.Function, chartData.MinXValue, chartData.MaxXValue, chartData.RadIncrement));

                    this.ChartModel.InvalidatePlot(true);

                    return ChartErrorCode.ok;
                }
                else if (string.IsNullOrEmpty(name))
                {
                    return ChartErrorCode.chartNameIsNull;
                }
                else if (chartData == null)
                {
                    return ChartErrorCode.chartDataIsNull;
                }
                else
                {
                    return ChartErrorCode.none;
                }
            }
            else
            {
                return ChartErrorCode.chartModelIsNull;
            }
            
        }
    }
}
