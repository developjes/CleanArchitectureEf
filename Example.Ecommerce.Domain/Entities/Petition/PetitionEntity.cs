using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Petition
{
    public class PetitionEntity : KeyIntegerTypeEntity
    {
        #region Fields

        public string? Radicate { get; set; }
        public bool Expired { get; set; }

        #endregion Fields

        #region relationship

        public EState StateId { get => (EState)_stateId; set => _stateId = (int)value; }
        private int _stateId;

        public int HeadLineId { get; set; }

        #endregion relationship

        #region Navigation Properties

        public virtual HeadLineEntity? HeadLine { get; set; }
        public virtual StateEntity? State { get; set; }

        #endregion Navigation Properties
    }
}