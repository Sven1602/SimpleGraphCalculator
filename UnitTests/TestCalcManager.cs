using LibrarySimpleGraphCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestSimpleGraphCalculator
{
    [TestClass]
    public class TestCalcManager
    {
        [TestMethod]
        public void CheckSinFunctionWithDegree()
        {
            ICalcManager calcManager = new CalcManager();
            var result = calcManager.CalculateWithDegree(new Sin(), 90);
            
            Assert.AreEqual(1,result);
        }


        [TestMethod]
        public void CheckSinFunctionWithRad()
        {
            ICalcManager calcManager = new CalcManager();
            double rad = Calculator.Radians(90);
            var result = calcManager.CalculateWithRad(new Sin(), rad);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CheckSinFunctionWithDegreeInvalid()
        {
            ICalcManager calcManager = new CalcManager();
            var result = calcManager.CalculateWithDegree(null, 90);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CheckSinFunctionWithRadInvalid()
        {
            ICalcManager calcManager = new CalcManager();
            double rad = Calculator.Radians(90);
            var result = calcManager.CalculateWithRad(null, rad);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CheckCosFunctionWithDegree()
        {
            ICalcManager calcManager = new CalcManager();
            var result = calcManager.CalculateWithDegree(new Cos(), 180);

            Assert.AreEqual(-1, result);
        }


        [TestMethod]
        public void CheckCosFunctionWithRad()
        {
            ICalcManager calcManager = new CalcManager();
            double rad = Calculator.Radians(180);
            var result = calcManager.CalculateWithRad(new Cos(), rad);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CheckCosFunctionWithDegreeInvalid()
        {
            ICalcManager calcManager = new CalcManager();
            var result = calcManager.CalculateWithDegree(null, 180);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CheckCosFunctionWithRadInvalid()
        {
            ICalcManager calcManager = new CalcManager();
            double rad = Calculator.Radians(180);
            var result = calcManager.CalculateWithRad(null, rad);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CheckSincFunctionWithDegree()
        {
            ICalcManager calcManager = new CalcManager();
            var result = calcManager.CalculateWithDegree(new Sinc(), 90);

            Assert.AreEqual(0.64, Math.Round(result,2));
        }


        [TestMethod]
        public void CheckSincFunctionWithRad()
        {
            ICalcManager calcManager = new CalcManager();
            double rad = Calculator.Radians(90);
            var result = calcManager.CalculateWithRad(new Sinc(), rad);

            Assert.AreEqual(0.64, Math.Round(result, 2));
        }

        [TestMethod]
        public void CheckSincFunctionWithDegreeInvalid()
        {
            ICalcManager calcManager = new CalcManager();
            var result = calcManager.CalculateWithDegree(null, 90);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CheckSincFunctionWithRadInvalid()
        {
            ICalcManager calcManager = new CalcManager();
            double rad = Calculator.Radians(90);
            var result = calcManager.CalculateWithRad(null, rad);

            Assert.AreEqual(0.0, result);
        }
    }
}
