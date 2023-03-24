namespace DogtrekkingCzShared.Testable
{
    public interface ITestableService
    {
        Task<TestResult> TestMeAsync();

        TestResult TestMe();
    }
}
