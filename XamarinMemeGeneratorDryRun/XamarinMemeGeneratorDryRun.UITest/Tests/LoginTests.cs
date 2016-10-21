using NUnit.Framework;
using Xamarin.UITest;

namespace XamarinMemeGeneratorDryRun.UITest.Tests
{
    [TestFixture]
    public class LoginTests : BaseTestFixture
    {
        public LoginTests(Platform platform) : base(platform)
        { }

        //TODO Add more tests
        [Test]
        public void LoginWithSuccess()
        {
            App.WaitForElement(Queries.ButtonLogin);
            App.Screenshot("Given the app is in the Main view");
        }

    }
}

