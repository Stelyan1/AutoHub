namespace AutoHub.Common
{
    public class EntityValidationConstants
    {
        public static class Brand
        {
            public const byte BrandNameMinLength = 3;
            public const byte BrandNameMaxLength = 60;

            public const byte FounderMinLength = 3;
            public const byte FounderMaxLength = 120;

            public const byte DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;
        }

        public static class Model
        {
            public const byte ModelNameMinLength = 3;
            public const byte ModelNameMaxLength = 60;

            public const byte FuelTypeMinLength = 6; 
            public const byte FuelTypeMaxLength = 6;

            public const byte DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;
        }

        public static class Engine
        {
            public const byte EngineNameMinLength = 3;
            public const byte EngineNameMaxLength = 40;

            public const byte ValveTrainMinLength = 4;
            public const byte ValveTrainMaxLength = 5;

            public const byte PowerOutputMinLength = 6;
            public const byte PowerOutputMaxLength = 20;

            public const byte TorqueMinLength = 6;
            public const byte TorqueMaxLength = 20;

            public const byte RpmMinLength = 7;
            public const byte RpmMaxLength = 20;

            public const byte YearsProductionMinLength = 9;
            public const byte YearsProductionMaxLength = 20;
        }

        public static class Gearbox
        {
            public const byte GearboxNameMinLength = 3;
            public const byte GearboxNameMaxLength = 40;

            public const byte TransmissionTypeMinLength = 6;
            public const byte TransmissionTypeMaxLength = 10;

            public const byte YearsProducedMinLength = 9;
            public const byte YearsProducedMaxLength = 20;

            public const byte DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 500;

            public const byte ManufacturerMinLength = 3;
            public const byte ManufacturerMaxLength = 40;
        }

        public static class Category
        {
            public const byte CategoryNameMinLength = 3;
            public const byte CategoryNameMaxLength = 30;
        }

        public static class Product
        {
            public const byte ProductNameMinLength = 3;
            public const byte ProductNameMaxLength = 60;

            public const byte ManufacturerMinLength = 3;
            public const byte ManufacturerMaxLength = 40;

            public const byte CarsApplicationMinLength = 3;
            public const byte CarsApplicationMaxLength = 40;

            public const byte DescriptionMinLength = 5;
            public const byte DescriptionMaxLength = 250;
        }
    }
}
