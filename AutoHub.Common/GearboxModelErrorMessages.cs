using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Common
{
    public class GearboxModelErrorMessages
    {
        public const string GearboxName = "Every gearbox should have a name";
        public const string TransmissionTypeMsg = "Every gearbox should be Manual or Automatic";
        public const string SpeedsMsg = "There is no gearbox without speeds at least 4";
        public const string YearsProducedMsg = "There's gotta be year when it's production started and ended";
        public const string ManufacturerMsg = "Every gearbox in manufactured by someone";
        public const string DescriptionMsg = "Every gearbox should have a little description";
        public const string ImageUrlMsg = "Every gearbox should have image";
        public const string ApplicationMsg = "Every gearbox is putted in a vehicle";
    }
}
