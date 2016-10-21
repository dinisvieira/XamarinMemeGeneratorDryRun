using NUnit.Framework;
using Xamarin.UITest;
using XamarinMemeGeneratorDryRun.UITest.Queries;
using XamarinMemeGeneratorDryRun.UITest.Configuration;

namespace XamarinMemeGeneratorDryRun.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class BaseTestFixture
    {
        protected IApp App;
        protected Platform Platform;
        protected IScreenQueries Queries;
        protected ITestRunConfiguration Config;

        public BaseTestFixture(Platform platform)
        {
            Platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Config = new MainLocalConfiguration();
            Queries = AppInitializer.InitializeQueries(Platform);
            App = AppInitializer.StartApp(Platform, Config);
        }

        [Test]
        public void OpenRepl()
        {
            App.Repl();
        }
    }
}

