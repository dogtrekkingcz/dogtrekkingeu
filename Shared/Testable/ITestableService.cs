namespace SharedCode.Testable
{
    public interface ITestableService
    {
        Task<TestResult> TestMeAsync();

        TestResult TestMe();
    }
}
