using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.EntityValidationConstants.Product;
    using static AutoHub.Common.ProductModelErrorMessages;
    public class ProductViewModel
    {
        [Required(ErrorMessage = ProductNameErrorMsg)]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = ManufacturerErrorMsg)]
        [MinLength(ManufacturerMinLength)]
        [MaxLength(ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = null!;

        [Required(ErrorMessage = CarsApplicationErrorMsg)]
        [MinLength(CarsApplicationMinLength)]
        [MaxLength(CarsApplicationMaxLength)]
        public string CarsApplication { get; set; } = null!;

        [Required(ErrorMessage = DescriptionErrorMsg)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = PriceErrorMsg)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = ImageUrlErrorMsg)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = AddedOnErrorMsg)]
        public DateTime AddedOn { get; set; } = DateTime.Now;

        [Required(ErrorMessage = CategoryErrorMsg)]
        public Guid CategoryId { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
            = new HashSet<Category>();
    }
}
