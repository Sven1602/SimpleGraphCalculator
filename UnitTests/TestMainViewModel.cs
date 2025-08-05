using CsvImportReview;
using LibrarySimpleGraphCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestSimpleGraphCalculator
{
    [TestClass]
    public class TestMainViewModel
    {
        [TestCleanup]
        public void Cleanup()
        {
            string filePath = "StoreData.xml";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            filePath = "ExportChartVectorFormat.svg";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void IfIsLoadCheckTheDefaultValues()
        {
            MainViewModel mainViewModel = new MainViewModel();
            Assert.IsTrue(mainViewModel.CurrentFunctionName == new Sin().Name);
            Assert.IsTrue(mainViewModel.XValue == 90);
            Assert.IsTrue(mainViewModel.MinXValue == -10);
            Assert.IsTrue(mainViewModel.MaxXValue == 10);
            Assert.IsTrue(mainViewModel.IncrementRad == 0.1);
            Assert.IsTrue(mainViewModel.CurrentUnit == EnumParameter.Deg.ToString());
        }

        [TestMethod]
        public void IfLoadStoreDateThenAssignThisValues()
        {

            string filePath = "StoreData.xml";
            File.Delete(filePath);

            StoreData expected = new StoreData();
            expected.XValue = 1.5;
            expected.MaxXValue = 10;
            expected.MinXValue = 0;
            expected.CurrentUnit = EnumParameter.Rad.ToString();
            expected.IncrementRad = 0.2;
            expected.Name = new Cos().Name;
            IDataManager dataManager = new DataManager();
            dataManager.Save(filePath, expected);

            MainViewModel mainViewModel = new MainViewModel();
            Assert.IsTrue(mainViewModel.CurrentFunctionName == new Cos().Name);
            Assert.IsTrue(mainViewModel.XValue == 1.5);
            Assert.IsTrue(mainViewModel.MinXValue == -0);
            Assert.IsTrue(mainViewModel.MaxXValue == 10);
            Assert.IsTrue(mainViewModel.IncrementRad == 0.2);
            Assert.IsTrue(mainViewModel.CurrentUnit == EnumParameter.Rad.ToString());

            File.Delete(filePath);
        }

        [TestMethod]
        public void IfCalculateCheckValue()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.CurrentFunctionName = new Sin().Name;
            mainViewModel.XValue = 90;
            mainViewModel.CurrentUnit = EnumParameter.Deg.ToString();

            Assert.IsTrue(0 == mainViewModel.FunctionValue);
            mainViewModel.CalcCommand.Execute(null);
            Assert.IsTrue(1 == mainViewModel.FunctionValue);
        }
    }
}
