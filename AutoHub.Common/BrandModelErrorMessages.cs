using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Common
{
    public class BrandModelErrorMessages
    {
        public static class Brand
        {
            public const string BrandNameIsRequired = "The Brand should have a name";
            public const string FounderIsRequired = "Every Brand should have founder/s";
            public const string FoundedDateIsRequired = "Every Brand should have a date when it's founded";
            public const string DescriptionIsRequired = "Every Brand should have a description";
            public const string ImageIsRequired = "The Brand should have a logo image to represent itself";
        }

    }
}
