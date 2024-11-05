using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.EntityValidationConstants.Model;
    using static AutoHub.Common.ModelViewErrorMessages.Model;
    public class ModelViewModel
    {
        [Required(ErrorMessage = ModelNameIsRequired)]
        [MinLength(ModelNameMinLength)]
        [MaxLength(ModelNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = YearIsRequired)]
        public int Year { get; set; } 

        [Required(ErrorMessage = HorsePowerRequired)]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = FuelTypeRequired)]
        [MinLength(FuelTypeMinLength)]
        [MaxLength(FuelTypeMaxLength)]
        public string FuelType { get; set; } = null!;

        [Required(ErrorMessage = GasConsumptionRequired)]
        [Range(4, 20)]
        public double GasConsumption { get; set; }

        [Required(ErrorMessage = DescriptionRequired)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ImageIsRequired)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = SelectBrandRequired)]
        public Guid SelectedBrand { get; set; } 

        public List<Brand> Brands { get; set; } 
            = new List<Brand>();
    }
}
