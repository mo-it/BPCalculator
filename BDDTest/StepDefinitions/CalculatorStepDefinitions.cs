using System;
using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace BPCalculator.BDDTests.StepDefinitions
{
    [Binding]
    public class BloodPressureSteps
    {
        private BloodPressure _bp = new();
        private BPCategory _result;
        private Exception? _exception;

        [Given(@"a systolic value of (.*)")]
        public void GivenASystolicValueOf(int systolic)
        {
            _bp.Systolic = systolic;
        }

        [Given(@"a diastolic value of (.*)")]
        public void GivenADiastolicValueOf(int diastolic)
        {
            _bp.Diastolic = diastolic;
        }

        [When(@"the blood pressure category is calculated")]
        public void WhenTheBloodPressureCategoryIsCalculated()
        {
            _exception = null;

            try
            {
                // Non-throwing path (matches most scenarios)
                _result = _bp.Category;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"the blood pressure category is retrieved")]
        public void WhenTheBloodPressureCategoryIsRetrieved()
        {
            _exception = null;

            try
            {
                // Strict path specifically for the OutOfRange scenario
                _result = _bp.GetCategoryOrThrow();
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string expected)
        {
            Assert.IsNull(_exception, $"Unexpected exception: {_exception}");
            Assert.AreEqual(Enum.Parse<BPCategory>(expected), _result);
        }

        [Then(@"an out of range exception should be thrown")]
        public void ThenAnOutOfRangeExceptionShouldBeThrown()
        {
            Assert.IsNotNull(_exception, "Expected an exception but none was thrown.");
            Assert.IsInstanceOfType(_exception, typeof(ArgumentOutOfRangeException));
        }
    }
}
