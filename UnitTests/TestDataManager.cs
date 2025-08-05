using LibrarySimpleGraphCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestSimpleGraphCalculator
{
    [TestClass]
    public class TestDataManager
    {
        [TestCleanup]
        public void Cleanup()
        {
            string filePath = "StoreData.xml";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void CheckSaveAndLoadDatas()
        {
            string filePath = "StoreData.xml";
          
            StoreData expected = new StoreData();
            expected.XValue = 90;
            expected.MaxXValue = 10;
            expected.MinXValue = -10;
            expected.FunctionValue = 1;
            expected.CurrentUnit = EnumParameter.Deg.ToString();
            expected.IncrementRad = 0.1;
            expected.Name = "sin(x)";
            IDataManager dataManager = new DataManager();
            dataManager.Save(filePath, expected);

            Assert.IsTrue(File.Exists(filePath));

            StoreData result = dataManager.Load(filePath);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.XValue == expected.XValue);
            Assert.IsTrue(result.FunctionValue == expected.FunctionValue);
            Assert.IsTrue(result.MinXValue == expected.MinXValue);
            Assert.IsTrue(result.MaxXValue == expected.MaxXValue);
            Assert.IsTrue(result.Name == expected.Name);
            Assert.IsTrue(result.IncrementRad == expected.IncrementRad);
            Assert.IsTrue(result.CurrentUnit == expected.CurrentUnit);
        }

        [TestMethod]
        public void CheckInvalidFilePath()
        {
            IDataManager dataManager = new DataManager();
            DataErrorCode error = dataManager.Save(string.Empty, new StoreData());
            
            Assert.IsTrue(error == DataErrorCode.filePathNotFound);
        }

        [TestMethod]
        public void CheckInvalidStoreData()
        {
            IDataManager dataManager = new DataManager();
            string filePath = "StoreData.xml";
            DataErrorCode error = dataManager.Save(filePath, null);

            Assert.IsTrue(error == DataErrorCode.dataParamIsNull);
        }
    }
}
