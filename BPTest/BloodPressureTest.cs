using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;
using System;

namespace BPCalculator.Tests
{
    [TestClass]
    public class BloodPressureTests
    {
        // ---------- Out of Range Tests ----------
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Category_Throws_WhenSystolicTooLow()
        {
            var bp = new BloodPressure { Systolic = 60, Diastolic = 70 };
            var category = bp.Category;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Category_Throws_WhenDiastolicTooHigh()
        {
            var bp = new BloodPressure { Systolic = 120, Diastolic = 150 };
            var category = bp.Category;
        }

        // ---------- High Blood Pressure Tests ----------
        [TestMethod]
        public void Category_ReturnsHigh_WhenSystolicHigh()
        {
            var bp = new BloodPressure { Systolic = 150, Diastolic = 70 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        [TestMethod]
        public void Category_ReturnsHigh_WhenDiastolicHigh()
        {
            var bp = new BloodPressure { Systolic = 120, Diastolic = 95 };
            Assert.AreEqual(BPCategory.High, bp.Category);
        }

        // ---------- Pre-High Tests ----------
        [TestMethod]
        public void Category_ReturnsPreHigh_WhenSystolicBetween120And139()
        {
            var bp = new BloodPressure { Systolic = 130, Diastolic = 70 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        [TestMethod]
        public void Category_ReturnsPreHigh_WhenDiastolicBetween80And89()
        {
            var bp = new BloodPressure { Systolic = 110, Diastolic = 85 };
            Assert.AreEqual(BPCategory.PreHigh, bp.Category);
        }

        // ---------- Ideal Tests ----------
        [TestMethod]
        public void Category_ReturnsIdeal_WhenInIdealRange()
        {
            var bp = new BloodPressure { Systolic = 110, Diastolic = 70 };
            Assert.AreEqual(BPCategory.Ideal, bp.Category);
        }

        // ---------- Low Tests ----------
        [TestMethod]
        public void Category_ReturnsLow_WhenBelowIdealRange()
        {
            var bp = new BloodPressure { Systolic = 80, Diastolic = 55 };
            Assert.AreEqual(BPCategory.Low, bp.Category);
        }
    }
}
