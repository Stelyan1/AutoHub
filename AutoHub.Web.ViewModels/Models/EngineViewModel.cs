using AutoHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Web.ViewModels.Models
{
    using static AutoHub.Common.EntityValidationConstants.Engine;
    using static AutoHub.Common.EngineModelErrorMessages;
    public class EngineViewModel
    {
        [Required(ErrorMessage = EngineNameMsg)]
        [MinLength(EngineNameMinLength)]
        [MaxLength(EngineNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ManufacturerMsg)]
        public Guid Manufacturer { get; set; }

        public List<Brand> Brands { get; set; }
             = new List<Brand>();

        [Required(ErrorMessage = ApplicationMsg)]
        public Guid Application { get; set; }

        public List<Model> Models { get; set; }
             = new List<Model>();

        [Required(ErrorMessage = CylindersMsg)]
        public int Cylinders { get; set; }

        [Required(ErrorMessage = ValveTrainDriveSystemMsg)]
        [MinLength(ValveTrainMinLength)]
        [MaxLength(ValveTrainMaxLength)]
        public string ValveTrainDriveSystem { get; set; } = null!;

        [Required(ErrorMessage = PowerOutputMsg)]
        [MinLength(PowerOutputMinLength)]
        [MaxLength(PowerOutputMaxLength)]
        public string PowerOutput { get; set; } = null!;

        [Required(ErrorMessage = TorqueMsg)]
        [MinLength(TorqueMinLength)]
        [MaxLength(TorqueMaxLength)]
        public string Torque { get; set; } = null!;

        [Required(ErrorMessage = RpmMsg)]
        [MinLength(RpmMinLength)]
        [MaxLength(RpmMaxLength)]
        public string Rpm { get; set; } = null!;

        [Required(ErrorMessage = ImageUrlMsg)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = YearsProducedMsg)]
        [MinLength(YearsProductionMinLength)]
        [MaxLength(YearsProductionMaxLength)]
        public string YearsProduction { get; set; } = null!;

    }
}
