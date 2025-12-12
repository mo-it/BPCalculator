using System;
using System.ComponentModel.DataAnnotations;

namespace BPCalculator
{
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    }

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }

        public int PulsePressure => Systolic - Diastolic;

        public BPCategory Category
        {
            get
            {
                // High: >=140 systolic OR >=90 diastolic
                if (Systolic >= 140 || Diastolic >= 90)
                    return BPCategory.High;

                // PreHigh: 120–139 systolic OR 80–89 diastolic
                if ((Systolic >= 120 && Systolic <= 139) || (Diastolic >= 80 && Diastolic <= 89))
                    return BPCategory.PreHigh;

                // Ideal: 90–119 systolic AND 60–79 diastolic
                if ((Systolic >= 90 && Systolic <= 119) && (Diastolic >= 60 && Diastolic <= 79))
                    return BPCategory.Ideal;

                // Otherwise Low (within allowed ranges, but below ideal thresholds)
                return BPCategory.Low;
            }
        }

        // Display string for UI (uses the Display attribute names)
        public string CategoryDisplay
        {
            get
            {
                var member = typeof(BPCategory).GetMember(Category.ToString());
                if (member.Length > 0)
                {
                    var attr = (DisplayAttribute?)Attribute.GetCustomAttribute(member[0], typeof(DisplayAttribute));
                    if (attr?.Name != null) return attr.Name;
                }
                return Category.ToString();
            }
        }
    }
}
