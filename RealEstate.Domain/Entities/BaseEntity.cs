using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
        }

        #region Class properties
        public Guid Id { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime? UpdatedDate { get; private set; }
        #endregion

        #region Public methods
        public void UpdateModificationDate()
        {
            UpdatedDate = DateTime.Now;
        }
        #endregion
    }
}
