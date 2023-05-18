using Example.Ecommerce.Transversal.Common.Enum;
using Example.Ecommerce.Transversal.Common.Extension;

namespace Example.Ecommerce.Transversal.Common.Utility
{
    public static class BirthDateUtility
    {
        private static DateTime GetTimeDifference(DateTime birthDate) =>
            new DateTime(1, 1, 1).DateTimeZoneInfo() + DateTime.Now.DateTimeZoneInfo().Subtract(birthDate);

        public static byte GetAgeRunnging(DateTime birthDate, EBirthDate ebirthDate = default)
        {
            DateTime timeDifference = GetTimeDifference(birthDate);
            byte ageYearsRunnging = (byte)(timeDifference.Year - 1);

            return ebirthDate switch
            {
                EBirthDate.Year => ageYearsRunnging,
                EBirthDate.Month => (byte)((ageYearsRunnging * 12) + timeDifference.Month - 1 - (ageYearsRunnging * 12)),
                EBirthDate.Day => (byte)(DateTime.Now.DateTimeZoneInfo() - birthDate.AddMonths(
                    (ageYearsRunnging * 12) + ((ageYearsRunnging * 12) + timeDifference.Month - 1 - (ageYearsRunnging * 12))
                )).Days,
                _ => ageYearsRunnging,
            };
        }
    }
}