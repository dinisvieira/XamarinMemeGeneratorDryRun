using System;
using Xamarin.UITest.Configuration;
using Xamarin.UITest;
using System.Collections.Generic;
using System.Linq;

namespace XamarinMemeGeneratorDryRun.UITest.SimulatorManager
{
    public static class IosSimulatorsManager
    {

        public static iOSAppConfigurator SetDeviceByName(this iOSAppConfigurator configurator, string simulatorName)
        {
            var deviceId = GetDeviceId(simulatorName);
            return configurator.DeviceIdentifier(deviceId);
        }

        public static string GetDeviceId(string simulatorName)
        {
            if (!TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                return string.Empty;
            }

            // See below for the InstrumentsRunner class.
            IEnumerable<Simulator> simulators = new InstrumentsRunner().GetListOfSimulators();

            var simulator = (from sim in simulators
                             where sim.Name.Equals(simulatorName)
                             select sim).FirstOrDefault();

            if (simulator == null)
            {
                throw new ArgumentException("Could not find a device identifier for '" + simulatorName + "'.", "simulatorName");
            }

            return simulator.GUID;
        }
    }
}

