namespace XamarinMemeGeneratorDryRun.UITest.Configuration
{
    public interface ITestRunConfiguration
    {
        /// <summary>
        /// Full path to the .APK file.
        /// </summary>
        string PathToAPK { get; }

        /// <summary>
        /// Full path to the .APP iOS Simulator app file.
        /// </summary>
        string PathToAPP { get; }

        string AndroidPackageName { get; }

        string IOSBundleID { get; }
    }
}

