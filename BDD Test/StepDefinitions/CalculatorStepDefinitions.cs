using BPCalculator;


namespace BPCalculator.BDDTests.StepDefinitions
{
    [Binding]
    public class BloodPressureSteps
    {
        private BloodPressure _bp;
        private BPCategory _result;
        private Exception _exception;

        [Given(@"a systolic value of (.*)")]
        public void GivenASystolicValueOf(int systolic)
        {
            _bp ??= new BloodPressure();
            _bp.Systolic = systolic;
        }

        [Given(@"a diastolic value of (.*)")]
        public void GivenADiastolicValueOf(int diastolic)
        {
            _bp ??= new BloodPressure();
            _bp.Diastolic = diastolic;
        }

        [When(@"the blood pressure category is calculated")]
        public void WhenTheBloodPressureCategoryIsCalculated()
        {
            try
            {
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
            try
            {
                var temp = _bp.Category;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string expected)
        {
            Assert.AreEqual(Enum.Parse<BPCategory>(expected), _result);
        }

        [Then(@"an out of range exception should be thrown")]
        public void ThenAnOutOfRangeExceptionShouldBeThrown()
        {
            Assert.IsNotNull(_exception);
            Assert.IsInstanceOfType(_exception, typeof(ArgumentOutOfRangeException));
        }
    }
}
