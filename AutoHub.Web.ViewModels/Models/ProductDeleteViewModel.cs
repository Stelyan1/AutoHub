using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.EntityValidationConstants.Product;
    using static AutoHub.Common.ProductModelErrorMessages;
    public class ProductDeleteViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public string SellerId { get; set; }
        public string Seller { get; set; }
    }
}
