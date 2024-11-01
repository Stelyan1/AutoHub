﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoHub.Data.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Id = Guid.NewGuid();
        }


        [Comment("Identifier of the brand")]
        public Guid Id { get; set; }

        [Comment("Name of the brand")]
        public string Name { get; set; } = null!;

        [Comment("Name of the founder/s")]
        public string FoundedBy { get; set; } = null!;

        public DateTime FoundedDate { get; set; }

        [Comment("Text for a little info about the company")]
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

    }
}
