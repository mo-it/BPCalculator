using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;
using System;

namespace BPCalculator.Tests
{
    [TestClass]
    public class BloodPressureTests
    {
        // ---------- Out of Range Tests (STRICT) ----------
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCategoryOrThrow_Throws_WhenSystolicTooLow()
        {
            var bp = new BloodPressure { Systolic = 60, Diastolic = 70 };
            _ = bp.GetCategoryOrThrow();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCategoryOrThrow_Throws_WhenSystolicTooHigh()
        {
            var bp = new BloodPressure { Systolic = 200, Diastolic = 80 };
            _ = bp.GetCategoryOrThrow();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCategoryOrThrow_Throws_WhenDiastolicTooLow()
        {
            var bp = new BloodPressure { Systolic = 120, Diastolic = 30 };
            _ = bp.GetCategoryOrThrow();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetCategoryOrThrow_Throws_WhenDiastolicTooHigh()
        {
            var bp = new BloodPressure { Systolic = 120, Diastolic = 150 };
            _ = bp.GetCategoryOrThrow();
        }

        // ---------- High ----------
        [DataTestMethod]
        [DataRow(140, 70)]
        [DataRow(120, 90)]
        [DataRow(160, 95)]
        public void Category_ReturnsHigh(int systolic, int diastolic)
        {
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        // ---------- PreHigh ----------
        [DataTestMethod]
        [DataRow(130, 70)]
        [DataRow(125, 85)]
        [DataRow(119, 82)]
        public void Category_ReturnsPreHigh(int systolic, int diastolic)
        {
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        // ---------- Ideal ----------
        [DataTestMethod]
        [DataRow(100, 70)]
        [DataRow(118, 65)]
        [DataRow(90, 60)]
        public void Category_ReturnsIdeal(int systolic, int diastolic)
        {
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };
            Assert.AreEqual(BPCategory.Ideal, bp.Category);
        }

        // ---------- Low ----------
        [DataTestMethod]
        [DataRow(85, 55)]
        [DataRow(75, 45)]
        [DataRow(89, 59)]
        public void Category_ReturnsLow(int systolic, int diastolic)
        {
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }

        // ---------- Pulse Pressure ----------
        [TestMethod]
        public void PulsePressure_IsCalculatedCorrectly()
        {
            var bp = new BloodPressure { Systolic = 120, Diastolic = 80 };
            Assert.AreEqual(40, bp.PulsePressure);
        }
    }
}
