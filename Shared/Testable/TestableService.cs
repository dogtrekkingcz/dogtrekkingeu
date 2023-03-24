namespace DogtrekkingCzShared.Testable
{
    internal class TestableService : ITestableService
    {
        public TestResult TestMe()
        {
            return new TestResult { Result = true };
        }

        public async Task<TestResult> TestMeAsync()
        {
            return new TestResult { Result = true };
        }
    }
}
