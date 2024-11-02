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
    }
}
