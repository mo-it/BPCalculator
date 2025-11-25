using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                // Out of range condition
                if (Systolic < 70 || Systolic > 190 || Diastolic < 40 || Diastolic > 100)
                {
                    throw new ArgumentOutOfRangeException("Values are out of valid range");
                }             
                //High Blood Pressure: Systolic >= 140 or Diastolic >= 90
                if (Systolic >= 140 || Diastolic >= 90)
                {
                    return BPCategory.High;
                }
                // Pre-High Blood Pressure: Systolic 121-139 or Diastolic 81-89
                else if (Systolic >= 120 || Diastolic >= 80)
                {
                    return BPCategory.PreHigh;
                }
                // Ideal Blood Pressure: Systolic 90-120 and Diastolic 60-80
           
                else if (Systolic >= 90 || Diastolic >= 60)
                {
                    return BPCategory.Ideal;
                }
                // Low Blood Pressure: Systolic 70-90 or Diastolic 40-60
                else
                {
                    return BPCategory.Low;
                }
            }
        }
    }
}