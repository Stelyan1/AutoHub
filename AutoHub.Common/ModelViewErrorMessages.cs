using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Common
{
    public class ModelViewErrorMessages
    {
        public static class Model
        {
           
                public const string ModelNameIsRequired = "The Model should have a name";
                public const string YearIsRequired = "Every model should have year";
                public const string HorsePowerRequired = "Every vehicle have horsepower";
                public const string FuelTypeRequired = "Every vehicle have fuel diesel or petrol";
                public const string GasConsumptionRequired = "Every vehicle has gas consumption";
                public const string DescriptionRequired = "Every model must have a description";
                public const string ImageIsRequired = "Every model should have image of itself";
                public const string SelectBrandRequired = "Please select brand to which the model belongs";

        }
    }
}
