﻿using System;
using XamarinMemeGeneratorDryRun.UITest.Configuration;
using XamarinMemeGeneratorDryRun.UITest.Queries;
using XamarinMemeGeneratorDryRun.UITest.SimulatorManager;
using Xamarin.UITest;

namespace XamarinMemeGeneratorDryRun.UITest
{
    public class AppInitializer
    {
        public static IScreenQueries InitializeQueries(Platform platform)
        {
            switch (platform)
            {
                case Platform.Android:
                    return new AndroidQueries();
                case Platform.iOS:
                    return new iOSQueries();
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }

        public static IApp StartApp(Platform platform, ITestRunConfiguration config)
        {
            if (TestEnvironment.Platform == TestPlatform.Local)
            {
                switch (platform)
                {
                    case Platform.Android:
                        return ConfigureApp.Android
                                //.EnableLocalScreenshots()
                                .ApkFile(config.PathToAPK)
                                .StartApp();
                    case Platform.iOS: //NOTE(avfe) This only supports iOS Simulator
                                       //ResetSimulator(deviceId);
						var deviceId = IosSimulatorsManager.GetDeviceId(IosSimulators.simTest);
                        return ConfigureApp.iOS
                            .DeviceIdentifier(deviceId) //Get Devices name in terminal: xcrun instruments -s devices
                            .AppBundle(config.PathToAPP)
                            //.InstalledApp("com.xpandit.caparticulares.iOS") //To be added only for a real device after installing app on device, must also comment the two lines above
                            .StartApp();
                }

                throw new NotImplementedException("Unknown local platform");
            }

            // Running on XTC 
            switch (platform)
            {
                case Platform.Android:
                    return ConfigureApp.Android.StartApp();
                case Platform.iOS:
                    return ConfigureApp.iOS.StartApp();
            }

            throw new NotImplementedException("Unknown XTC platform");
        }
    }
}