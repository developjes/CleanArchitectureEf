using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Transversal.Common.Enum;
using Example.Ecommerce.Transversal.Common.Utility;
using NetTopologySuite.Geometries;

namespace Example.Ecommerce.Domain.Entities.Petition
{
    public class HeadLineEntity : KeyIntegerTypeEntity
    {
        #region Fields

        public string? IdentificationNumber { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Point? Location { get; set; }

        #endregion Fields

        #region Calculated
        /*
        #if __MOBILE__
        #endif

        #if __WIN32__
        #endif
        */
        public string? FullName { get =>
                string.Join(' ', new string[] { FirstName!, SecondName!, FirstLastName!, SecondLastName! }
                    .Where(fn => !string.IsNullOrWhiteSpace(fn))); }

        public byte AgeYearsRunning { get => BirthDateUtility.GetAgeRunnging(BirthDate, EBirthDate.Year); }
        public byte AgeMonthsRunning { get => BirthDateUtility.GetAgeRunnging(BirthDate, EBirthDate.Month); }
        public byte AgeDaysRunning { get => BirthDateUtility.GetAgeRunnging(BirthDate, EBirthDate.Day); }

#endregion Calculated

        #region RelationShip

        public int IdentificationTypeId { get; set; }

        #endregion RelationShip

        #region Navigation

        public virtual IdentificationTypeEntity? IdentificationType { get; set; }
        public virtual ICollection<PetitionEntity>? Petitions { get; set; }
        public virtual ICollection<BeneficiaryEntity>? Beneficiaries { get; set; }

        #endregion Navigation
    }
}