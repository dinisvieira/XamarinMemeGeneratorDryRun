using NUnit.Framework;
using Xamarin.UITest;
using XamarinMemeGeneratorDryRun.UITest.Extensions;

namespace XamarinMemeGeneratorDryRun.UITest.Tests
{
    [TestFixture]
    public class MemeTests : BaseTestFixture
    {
        public MemeTests(Platform platform) : base(platform)
        { }

        //TODO Add more tests
        [Test]
        public void GenerateMeme()
        {
            App.Wait(2);
            App.WaitForElement(Queries.ButtonGenerateMeme);
            App.Tap(Queries.ButtonGenerateMeme);
            App.Wait(2);
            App.Screenshot("After I tap the button, I can see a meme image.");
        }

    }
}

