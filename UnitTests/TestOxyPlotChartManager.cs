using LibrarySimpleGraphCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGraphCalculator;
using System.IO;


namespace TestSimpleGraphCalculator
{
    [TestClass]
    public class TestOxyPlotChartManager
    {
        [TestCleanup]
        public void Cleanup()
        {
            string filePath = "ExportChartVectorFormat.svg";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void IfUpdateChartTheSeriesIsNotEmpty()
        {
            OxyPlotChartManager chartManager = new OxyPlotChartManager();

            Assert.IsTrue(chartManager.ChartModel.Series.Count == 0);
            chartManager.UpdateChart(new Sin().Name, new ChartData
            {
                Function = new Sin().Calc,
                MaxXValue = 10,
                MinXValue = 0,
                Name = "sin(x)",
                RadIncrement = 0.1,
            });

            Assert.IsNotNull(chartManager.ChartModel);
            Assert.IsTrue(chartManager.ChartModel.Series.Count > 0);
        }


        [TestMethod]
        public void IfExportThenExitsSvgFile()
        {
            OxyPlotChartManager chartManager = new OxyPlotChartManager();
            string filePath = "export.svg";

            Assert.IsFalse(File.Exists(filePath));

            var result = chartManager.exportChartToSvg(filePath, 600, 600);

            Assert.IsTrue(result == ChartErrorCode.ok);
            Assert.IsTrue(File.Exists(filePath));
            File.Delete(filePath);
        }

        [TestMethod]
        public void CheckExportWithInvalidData()
        {
            OxyPlotChartManager chartManager = new OxyPlotChartManager();
   
            var result = chartManager.exportChartToSvg(null, 0, 0);

            Assert.IsTrue(result == ChartErrorCode.filePathNotFound);
        }

        [TestMethod]
        public void CheckUpdateChartWithInvalidData()
        {
            OxyPlotChartManager chartManager = new OxyPlotChartManager();

            var result = chartManager.UpdateChart(null, new ChartData());

            Assert.IsTrue(result == ChartErrorCode.chartNameIsNull);

            result = chartManager.UpdateChart("sind(x)", null);

            Assert.IsTrue(result == ChartErrorCode.chartDataIsNull);
        }
    }
}
