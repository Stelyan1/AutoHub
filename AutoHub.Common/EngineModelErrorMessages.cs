using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Common
{
    public class EngineModelErrorMessages
    {
        public const string EngineNameMsg = "Every engine should have a name";
        public const string ManufacturerMsg = "Every engine should have a manufacturer";
        public const string ApplicationMsg = "Every engine is applied to a given vehicle";
        public const string CylindersMsg = "There is no engine without cylinders";
        public const string ValveTrainDriveSystemMsg = "Please type a drive system";
        public const string PowerOutputMsg = "Every engine should have horsepower";
        public const string TorqueMsg = "Every engine should have Nm";
        public const string RpmMsg = "Every engine should have RPM";
        public const string ImageUrlMsg = "Every engine should have image";
        public const string YearsProducedMsg = "Every engine is produced from given year";
    }
}
