﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChart.Data
{
    public class Starship
    {
        [Required]
        [StringLength(16,
        ErrorMessage = "The Identifier exceeds 16 characters.")]
        public string Identifier { get; set; }

        [Required]
        public string Classification { get; set; }

        [Range(1, 100000, ErrorMessage = "The Maximum Accommodation value should be a number between 1 and 100,000.")]
        public int MaximumAccommodation { get; set; }

        [Required]
        [DateInPastAttribute(ErrorMessage = "The Production Date value cannot be later than today.")]
        public DateTime ProductionDate { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value <= DateTime.Today;
        }
    }
}
