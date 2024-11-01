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

            public const byte DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 500;
        }
    }
}
