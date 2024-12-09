using AutoHub.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.GearboxModelErrorMessages;
    using static AutoHub.Common.EntityValidationConstants.Gearbox;
   public class GearboxViewModel
   {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = GearboxName)]
        [MinLength(GearboxNameMinLength)]
        [MaxLength(GearboxNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = TransmissionTypeMsg)]
        [MinLength(TransmissionTypeMinLength)]
        [MaxLength(TransmissionTypeMaxLength)]
        public string TransmissionType { get; set; } = null!;

        [Required(ErrorMessage = SpeedsMsg)]
        [Range(4, 8, ErrorMessage = "Speeds should range from 4 to 10")]
        public int Speeds { get; set; }

        [Required(ErrorMessage = YearsProducedMsg)]
        [MinLength(YearsProducedMinLength)]
        [MaxLength(YearsProducedMaxLength)]
        public string YearsProduced { get; set; } = null!;

        [Required(ErrorMessage = ManufacturerMsg)]
        [MinLength(ManufacturerMinLength)]
        [MaxLength(ManufacturerMaxLength)]
        public string Manufacturer { get; set; } = null!;

        [Required(ErrorMessage = DescriptionMsg)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ImageUrlMsg)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = ApplicationMsg)]
        public Guid Application { get; set; }

        public List<Model> Models { get; set; }
             = new List<Model>();

    }
}
