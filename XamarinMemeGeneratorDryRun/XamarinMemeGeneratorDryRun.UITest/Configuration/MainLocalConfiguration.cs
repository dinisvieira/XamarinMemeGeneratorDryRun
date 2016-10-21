using System;
using System.IO;
using System.Reflection;

namespace XamarinMemeGeneratorDryRun.UITest.Configuration
{
    /// <summary>
    /// Main configuration file for local UI testing. This implementation should cover most cases. 
    /// 
    /// More advance usage scenarios might include multiple configurations for
    /// multiple conditional app builds (e.g., one for TEST env, another for QA, etc...).
    /// </summary>
    internal class MainLocalConfiguration : ITestRunConfiguration
    {
        public string PathToAPK { get { return Path.Combine(SlnPath, "XamarinMemeGeneratorDryRun.Droid", "bin", "Release", "com.XamarinMemeGeneratorDryRun.apk"); } }
        public string PathToAPP { get { return Path.Combine(SlnPath, "XamarinMemeGeneratorDryRun.UITest", "bin", "iPhoneSimulator", "Debug", "XamarinMemeGeneratorDryRun.iOS.app"); } }
        public string AndroidPackageName { get { return "com.XamarinMemeGeneratorDryRun"; } }
        public string IOSBundleID { get { return "com.xamarinmemegeneratordryrun.ios"; } } 

        private string _slnPath = null;
        private string SlnPath
        {
            get
            {
                if (_slnPath != null)
                    return _slnPath;

                string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                FileInfo fi = new FileInfo(currentFile);
                _slnPath = fi.Directory.Parent.Parent.Parent.FullName;

                return _slnPath;
            }
        }
    }
}

